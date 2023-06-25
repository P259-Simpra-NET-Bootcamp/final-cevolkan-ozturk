using ECommerce.Base;
using ECommerce.Operation;
using ECommerce.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ECommerce.Service.Controllers
{
    [EnableMiddlewareLogger]
    [ResponseGuid]
    [Route("simapi/v1/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService tokenService;

        private readonly IUserService userService;

        public TokenController(ITokenService tokenService, IUserService userService)
        {
            this.tokenService = tokenService;
            this.userService = userService;
        }

        [HttpPost("SignIn")]
        public ApiResponse<TokenResponse> SignIn([FromBody] TokenRequest request)
        {
            return tokenService.GetToken(request);
        }

        [HttpPost("SignUp")]
        public ApiResponse Post([FromBody] UserRequest request)
        {
            var response = userService.Insert(request);
            return response;
        }
    }
}
