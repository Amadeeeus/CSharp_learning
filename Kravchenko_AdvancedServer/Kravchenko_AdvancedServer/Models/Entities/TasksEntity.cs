namespace Kravchenko_AdvancedServer.Models.Entities;

public class TasksEntity
{
    public DateTime CreatedAt { get; set; }
    public int Id { get; set; }
    public bool Status { get; set; }
    public string? Text {get; set; }
    public DateTime UpdatedAt { get; set; }
}