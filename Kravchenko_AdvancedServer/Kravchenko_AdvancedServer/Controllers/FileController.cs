using System.ComponentModel.DataAnnotations;
using Kravchenko_AdvancedServer.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Kravchenko_AdvancedServer.Controllers;


[Route("v1/file")]
[ApiController]
public class FileController : ControllerBase
{
/*    private readonly string currentPath = Path.Combine(Directory.GetCurrentDirectory(), "StaticFile");
    private readonly ILogger<FileController> _logger;
    private readonly IFileService _fileService;

    public FileController(ILogger<FileController> logger, IFileService fileService)
    {
        _logger = logger;
        _fileService = fileService;
    }


    [HttpGet("{filename}")]
    public async Task<IResult> GetFileAsync(string filename)
    {
        var filepath = Path.Combine(currentPath, filename);
        var result = await _fileService.GetFile(filepath);
        if (result == null)
        {
            _logger.LogWarning("Error! Missing file in {0}", filepath);
            return Results.BadRequest(new BaseSuccessResponse
                {
                    Success = false,
                    StatusCode = StatusCodes.Status400BadRequest
                });
        }

        _logger.LogInformation("File{1} found in {0}", filepath, filename);
        return Results.File(result.FileContents, result.ContentType, result.FileDownloadName);
    }

    [HttpPost("uploadFile")]
    public async Task<IResult> UploadFileAcync([Required] IFormFile file)
    {
        var result = await _fileService.UploadFileAsync(file,currentPath);
        _logger.LogInformation("File {1} uploaded to {0}", currentPath, file.FileName);
        return Results.Ok(result);
    }

*/
}