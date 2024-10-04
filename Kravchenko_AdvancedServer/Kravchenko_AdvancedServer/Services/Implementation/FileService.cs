using Kravchenko_AdvancedServer.Controllers;
using Kravchenko_AdvancedServer.Models.File;
using Kravchenko_AdvancedServer.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Kravchenko_AdvancedServer.Services;

public class FileService : IFileService
{
    private readonly ILogger<FileService> _logger;
    private readonly IWebHostEnvironment _webHostEnvironment;
    
    public FileService(ILogger<FileService> logger, IWebHostEnvironment webHostEnvironment)
    {
        _logger = logger;
        _webHostEnvironment = webHostEnvironment;
    }

    
    public Task<string> GetFile(string fileName)
    {
        var path = Path.Combine(_webHostEnvironment.WebRootPath,"resources");
        var pathToFile = Path.Combine(path, fileName);
        if (File.Exists(pathToFile))
        {
            _logger.LogInformation($"GetFileAsync: File {fileName} exists");
            _logger.LogInformation($"GetFileAsync: Path{pathToFile}");
            return Task.FromResult(pathToFile);
        }
        _logger.LogInformation($"GetFileAsync: File {fileName} not found");
        return Task.FromResult<string>(null);
    }

    public async Task<string> UploadFileAsync(IFormFile file)
    {
        var filename = $"{Guid.NewGuid().ToString()}{Path.GetExtension(file.FileName)}";
        var path = Path.Combine(_webHostEnvironment.WebRootPath,"resources");
        if (!Directory.Exists(path))
        {
            _logger.LogInformation("Directory doesn't exist. Creating...");
            Directory.CreateDirectory(path);
        }
        _logger.LogInformation("Directory exists!");
        var pathToFile = Path.Combine(path, filename);
        if (!File.Exists(pathToFile))
        {
            _logger.LogInformation("File uploaded");
            await using (var stream = new FileStream(pathToFile, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            
            return pathToFile;
        }
        _logger.LogInformation("File already exists!");
        return null;
    }
    public string GetMimeType(string filePath)
    {
        var ext = Path.GetExtension(filePath).ToLowerInvariant();
        return ext switch
        {
            ".jpg" or ".jpeg" => "image/jpeg",
            ".png" => "image/png",
            ".gif" => "image/gif",
            _=>"application/octet-stream"
        };
    }
}