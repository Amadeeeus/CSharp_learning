// ReSharper disable All
namespace Kravchenko_AdvancedServer.Models.DTOs;
using System.ComponentModel.DataAnnotations;
public class AuthDto
{
    [StringLength(100, MinimumLength = 3)]
    public string? Email { get; set; }

    public string? Password { get; set;}
}