namespace Kravchenko_AdvancedServer.Models.DTOs;

public class GetNewsOutDto
{
    public string? Description {get; set; }
    public int Id { get; set; }
    public string? Image {get; set; }
    public string[]? Tags { get; set; } = [];
    public string? Title { get; set; }
    public string? UserId { get; set; }
    public string? Username { get; set; }
}