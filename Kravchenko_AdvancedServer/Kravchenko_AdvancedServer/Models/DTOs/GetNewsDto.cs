namespace Kravchenko_AdvancedServer.Models.DTOs;

public class GetNewsDto<T>
{
    public T? Content { get; set; }
    public string? NotReady { get; set; }
    public string? NumberOfElements { get; set; }
    public string? Ready { get; set; }
}