using System.ComponentModel.DataAnnotations;
using Kravchenko_AdvancedServer.Models.Responses;
using Kravchenko_AdvancedServer.Services;
using Microsoft.AspNetCore.Mvc;
using Sprache;

namespace Kravchenko_AdvancedServer.Controllers;


[Route("file")]
[ApiController]
public class FileController : ControllerBase
{
    private readonly ILogger<FileController> _logger;
    private readonly IFileService _fileService;

    public FileController(ILogger<FileController> logger, IFileService fileService)
    {
        _logger = logger;
        _fileService = fileService;
    }

    [HttpPost("uploadFile")]
    public async Task<ActionResult<CustomSuccessResponse<string>>> UploadFileAsync([Required] IFormFile file)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogInformation($"Bad Request in:UploadFile");
            return BadRequest(ModelState);
        }
        var result = await _fileService.UploadFileAsync(file);
        _logger.LogInformation($"File {file.FileName} is start upload");
        return new CustomSuccessResponse<string>()
        {
            StatusCode = StatusCodes.Status200OK,
            Success = true,
            Data = result
        };
    }

    [HttpGet("{filename}")]
    public async Task<IActionResult> GetFileAsync(string filename)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogInformation($"BadRequest in:GetFile");
            return BadRequest();
        }
        _logger.LogInformation($"Finding: {filename}");
        var result = await _fileService.GetFile(filename);
        if (string.IsNullOrEmpty(result))
        {
            _logger.LogWarning($"File {filename} not found");
            return NotFound();
        }

        var mimeType = _fileService.GetMimeType(filename);
        _logger.LogInformation($"File {filename} found: {mimeType}");
        return PhysicalFile(result, mimeType);
    }

    

}