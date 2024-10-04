using Kravchenko_AdvancedServer.Models.Responses;

namespace Kravchenko_AdvancedServer.Services;

public interface IFileService
{
    Task<string> GetFile(string fileName);
    Task<string> UploadFileAsync(IFormFile file);
    string GetMimeType(string fileName);
}