using Kravchenko_AdvancedServer.Models;
using Kravchenko_AdvancedServer.Models.DTOs;

namespace Kravchenko_AdvancedServer.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAllUsersAsync();
    Task<User> GetUserInfoAsync(Guid UserId);
    Task<User> GetUserByIdAsync(Guid UserId);
    Task<User> PutUserAsync(PutUserDto dto,Guid UserId);
    Task DeleteUserAsync(Guid UserId);
    Task<User> GetUserByEmailAsync(string email);
}