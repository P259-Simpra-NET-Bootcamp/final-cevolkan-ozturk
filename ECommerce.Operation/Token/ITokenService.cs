using ECommerce.Base;
using ECommerce.Schema;

namespace ECommerce.Operation;

public interface ITokenService
{
    ApiResponse<TokenResponse> GetToken(TokenRequest request);
}
