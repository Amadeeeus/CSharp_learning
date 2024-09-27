using Kravchenko_AdvancedServer.Models.View;

namespace Kravchenko_AdvancedServer.Models;

public class Tag
{
    public long Id { get; set; }
    public string Title { get; set; }
    public ICollection<News>? News { get; set; } = new List<News>();
}