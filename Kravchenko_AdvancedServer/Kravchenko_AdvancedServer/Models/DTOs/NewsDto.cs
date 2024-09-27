namespace Kravchenko_AdvancedServer.Models.DTOs;
using System.ComponentModel.DataAnnotations;
public class NewsDto
{
    [StringLength(160, MinimumLength = 3)]
    public string? Description { get; set; }
    [StringLength(130, MinimumLength = 3)] 
    public string? Image { get; set; }
    public string[] Tags { get; set; } = [];
    [StringLength(160, MinimumLength = 3)]
    public string? Title { get; set; }
}