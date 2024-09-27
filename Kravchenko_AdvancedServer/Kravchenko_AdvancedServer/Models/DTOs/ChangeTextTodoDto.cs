namespace Kravchenko_AdvancedServer.Models.DTOs;
using System.ComponentModel.DataAnnotations;
public class ChangeTextTodoDto
{
    [StringLength(160, MinimumLength = 3)]
    public string? Text { get; set; }
}