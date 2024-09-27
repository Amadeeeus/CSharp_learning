using Microsoft.AspNetCore.Identity;

namespace Kravchenko_AdvancedServer.Models;

public class User
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Role { get; set; }
    public string? Password { get; set; }
    public string? Avatar { get; set; }
}