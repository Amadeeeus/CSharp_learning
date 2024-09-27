namespace Kravchenko_AdvancedServer.Models.Responses;

public class CreateNewSuccessResponse
{
    public Guid Id { get; set; }
    public int StatusCode { get; set; }
    public bool Success {get; set; }
}