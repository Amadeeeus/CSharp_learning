using Kravchenko_AdvancedServer.Models;
using Microsoft.EntityFrameworkCore;

namespace Kravchenko_AdvancedServer.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly AppDbContext _context;
    private readonly ILogger<AuthRepository> _logger;

    public AuthRepository(AppDbContext context, ILogger<AuthRepository> logger)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<User?> AddUserAsync(User user)
    {
        try
        {
            _logger.LogInformation("User with email {1} added in database",user.Email);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            _logger.LogWarning("Error adding in database");
            throw;
        }
        return user;
    }

    public async Task<User?> GetUserAsync(string email)
    {
        {
            _logger.LogInformation("User {1} was found in database", email);
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}