namespace Kravchenko_AdvancedServer.Models.View;

public class News
{
    public long Id { get; set; }
    public string? Description { get; set; }
    public string? Title { get; set; }
    public string? Image { get; set; }
    public ICollection<Tag>? Tags {get; set; } = new List<Tag>();
    public User? User{ get; set;}
}