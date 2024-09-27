namespace Kravchenko_AdvancedServer.Models.Responses;

public class CustomSuccessResponse<T>
{
    public T? Data { get; set; }
    public int StatusCode { get; set; }
    public bool Success { get; set; }
}