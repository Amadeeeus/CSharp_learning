using Kravchenko_AdvancedServer.Models;

namespace Kravchenko_AdvancedServer.Repositories;

public interface IAuthRepository
{
    Task<User?> AddUserAsync(User user);
    Task<User?> GetUserAsync(string email);
}