using Kravchenko_AdvancedServer.Models.DTOs;

namespace Kravchenko_AdvancedServer.Models.Responses;

public class PageableResponse<T>
{
    public T? Content { get; set; }
    public int NumberOfElements { get; set; }
}