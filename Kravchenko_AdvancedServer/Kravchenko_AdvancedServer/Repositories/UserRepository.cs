using Kravchenko_AdvancedServer.Models;
using Kravchenko_AdvancedServer.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Kravchenko_AdvancedServer.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    private readonly ILogger<UserRepository> _logger;

    public UserRepository(AppDbContext context, ILogger<UserRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetUserInfoAsync(Guid UserId)
    {
        return (await _context.Users.FirstOrDefaultAsync(x => x.Id == UserId))!;
    }

    public async Task<User> GetUserByIdAsync(Guid UserId)
    {
        return (await _context.Users.FirstOrDefaultAsync(x => x.Id == UserId))!;
    }

    public async Task<User> PutUserAsync(PutUserDto dto, Guid UserId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == UserId);
        if (user == null)
        {
            _logger.LogWarning($"User With id:{UserId} not found");
            throw new KeyNotFoundException("User not found");
        }
        
        user.Email = dto.Email;
        user.Avatar = dto.Avatar;
        user.Name = dto.Name;
        user.Role = dto.Role;
        user.Password = user.Password;
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task DeleteUserAsync(Guid UserId)
    {
        _context.Users.Remove(await _context.Users.FirstOrDefaultAsync(x => x.Id == UserId));
        await _context.SaveChangesAsync();
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(x=>x.Email==email);
    }

}