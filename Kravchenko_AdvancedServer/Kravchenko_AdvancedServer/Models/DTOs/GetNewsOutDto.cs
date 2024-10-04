namespace Kravchenko_AdvancedServer.Models.DTOs;

public class GetNewsOutDto
{
    public string? Description {get; set; }
    public long? Id { get; set; }
    public string? Image {get; set; }
    public string[]? Tags { get; set; } = [];
    public string? Title { get; set; }
    public Guid UserId { get; set; }
    public string? Username { get; set; }
}