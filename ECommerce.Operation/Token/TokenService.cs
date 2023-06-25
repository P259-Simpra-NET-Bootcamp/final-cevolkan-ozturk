using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ECommerce.Base;
using ECommerce.Data;
using ECommerce.Data.Uow;
using ECommerce.Schema;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ECommerce.Domain;

namespace ECommerce.Operation;

public class TokenService : ITokenService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly JwtConfig jwtConfig;

    public TokenService(IUnitOfWork unitOfWork,IOptionsMonitor<JwtConfig> jwtConfig)
    {
        this.unitOfWork = unitOfWork;   
        this.jwtConfig = jwtConfig.CurrentValue;
    }

    public ApiResponse<TokenResponse> GetToken(TokenRequest request)
    {
        if (request is null)
        {
            return new ApiResponse<TokenResponse>("Request was null");
        }
        if (string.IsNullOrEmpty(request.UserName) || string.IsNullOrEmpty(request.Password))
        {
            return new ApiResponse<TokenResponse>("Request was null");
        }

        request.UserName = request.UserName.Trim().ToLower();
        request.Password = request.Password.Trim();
        
        var user = unitOfWork.Repository<User>().Where(x => x.UserName.Equals(request.UserName)).FirstOrDefault();
        if (user is null)
        {
            return new ApiResponse<TokenResponse>("Invalid user informations");
        }
        if (user.Password.ToLower() != CreateMD5(request.Password))
        {
            user.PasswordRetryCount++;
            user.LastActivity = DateTime.UtcNow;

            if (user.PasswordRetryCount > 3)
                user.Status = 2;

            unitOfWork.Repository<User>().Update(user);
            unitOfWork.Complete();

            return new ApiResponse<TokenResponse>("Invalid user informations");
        }

        if (user.Status != 1)
        {
            return new ApiResponse<TokenResponse>("Invalid user status");
        }
        if (user.PasswordRetryCount > 3)
        {
            return new ApiResponse<TokenResponse>("Password retry count exceded");
        }

        user.LastActivity = DateTime.UtcNow;
        user.Status = 1;


        unitOfWork.Repository<User>().Update(user);
        unitOfWork.Complete();

        TokenResponse response = new();
        response.UserName = request.UserName;
        response.AccessToken = Token(user);
        response.ExpireTime = DateTime.Now.AddMinutes(jwtConfig.AccessTokenExpiration);

        return new ApiResponse<TokenResponse>(response);
    }

    private string Token(User user)
    {
        Claim[] claims = GetClaims(user);
        var secret = Encoding.ASCII.GetBytes(jwtConfig.Secret);

        var jwtToken = new JwtSecurityToken(
            jwtConfig.Issuer,
            jwtConfig.Audience,
            claims,
            expires: DateTime.Now.AddMinutes(jwtConfig.AccessTokenExpiration),
            signingCredentials : new SigningCredentials(new SymmetricSecurityKey(secret),SecurityAlgorithms.HmacSha256Signature)
            );

        var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        return accessToken;
     }

    private Claim[] GetClaims(User user)
    {
        var claims = new[]
        {
            new Claim("UserName",user.UserName),
            new Claim("UserId",user.Id.ToString()),
            new Claim("FirstName",user.Name),
            new Claim("LastName",user.Surname),
            new Claim("UserName",user.UserName),
            new Claim("LastActivity",user.LastActivity.ToString()),
            new Claim("Role",user.Role),
            new Claim("Status",user.Status.ToString()),
            new Claim(ClaimTypes.Role,user.Role),
            new Claim(ClaimTypes.Name,$"{user.Name} {user.Surname}")
        };

        return claims;
    }

    private string CreateMD5(string input)
    {
        using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes).ToLower();

        }
    }
}