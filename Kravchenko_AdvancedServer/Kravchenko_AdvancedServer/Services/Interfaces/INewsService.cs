using Kravchenko_AdvancedServer.Models.DTOs;
using Kravchenko_AdvancedServer.Models.Responses;

namespace Kravchenko_AdvancedServer.Services;

public interface INewsService
{
    Task<CustomSuccessResponse<PageableResponse<List<GetNewsOutDto>>>> GetNewsAsync(int pageNumber,
        int pageSize);

    Task<CustomSuccessResponse<PageableResponse<List<GetNewsOutDto>>>> FindNewsAsync(int pageNumber,
        int pageSize, string? author, string? keyword, string?[] tags);

    Task<CustomSuccessResponse<PageableResponse<List<GetNewsOutDto>>>> FindNewsByIdAsync(long newsId,
        int pageNumber, int pageSize);

    Task<CreateNewSuccessResponse>CreateNewsAsync(NewsDto? newsDto, Guid userId);
    Task<BaseSuccessResponse> UpdateNewsAsync(long? id, NewsDto? newsDto, Guid userId);
    Task<BaseSuccessResponse> DeleteNewsAsync(long? id);
}