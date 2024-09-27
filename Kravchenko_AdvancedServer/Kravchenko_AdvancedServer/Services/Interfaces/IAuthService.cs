using Kravchenko_AdvancedServer.Models;
using Kravchenko_AdvancedServer.Models.DTOs;
using Kravchenko_AdvancedServer.Models.Responses;

namespace Kravchenko_AdvancedServer.Services;

public interface IAuthService
{
    Task<CustomSuccessResponse<LoginUserDto>> RegisterAsync(RegisterUserDto dto);
    Task<CustomSuccessResponse<LoginUserDto>> LoginAsync(string email, string password);
}