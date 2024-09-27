namespace Kravchenko_AdvancedServer.Models.DTOs;
using System.ComponentModel.DataAnnotations;
public class PutUserDto
{
    public string? Avatar { get; set; }
    [StringLength(100, MinimumLength = 3)]
    public string? Email { get; set; }
    [StringLength(25,MinimumLength = 3)]
    public string? Name { get; set; }
    public string? Role {get; set; }
}