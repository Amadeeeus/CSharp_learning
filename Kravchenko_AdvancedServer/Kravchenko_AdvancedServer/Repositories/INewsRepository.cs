using Kravchenko_AdvancedServer.Models.DTOs;
using Kravchenko_AdvancedServer.Models.View;

namespace Kravchenko_AdvancedServer.Repositories;

public interface INewsRepository
{
    Task<IEnumerable<News?>> GetNewsAsync(int pageNumber, int pageSize);
    Task<IEnumerable<News?>> FindNewsAsync(int pageNumber, int pageSize, string? author, string? keyword, string?[] tags);
    Task<IEnumerable<News?>> FindNewsByIdAsync(long newsId, int pageNumber, int pageSize);
    Task<long?> CreateNewsAsync(NewsDto dto, Guid userId);
    Task<bool> PutNewsAsync(long? id, NewsDto dto, Guid userId);
    Task DeleteNewsAsync(long? id);
}