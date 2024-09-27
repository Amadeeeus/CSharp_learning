using Kravchenko_AdvancedServer.Models.DTOs;
using Kravchenko_AdvancedServer.Models.Responses;
using Kravchenko_AdvancedServer.Models.View;

namespace Kravchenko_AdvancedServer.Services;

public interface IUserService
{
    Task<CustomSuccessResponse<List<PublicUserView>>> GetAllUsersAsync();
    Task<CustomSuccessResponse<PublicUserView>> GetUserInfoAsync(Guid userId);
    Task<CustomSuccessResponse<PublicUserView>> GetUserByIdAsync(Guid id);
    Task<CustomSuccessResponse<PutUserDtoResponse>> PutUserAsync(PutUserDto dto,Guid userId);
    Task<BaseSuccessResponse> DeleteUserAsync(Guid id);
}