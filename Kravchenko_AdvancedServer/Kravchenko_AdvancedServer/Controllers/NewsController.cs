using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.IdentityModel.Tokens;
using System.Text;
using Kravchenko_AdvancedServer.Models.DTOs;
using Kravchenko_AdvancedServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;
namespace Kravchenko_AdvancedServer.Controllers;
using System.ComponentModel.DataAnnotations;


[Route("news")] 
[ApiController]
public class NewsController:ControllerBase
{
       
      private readonly ILogger<NewsController> _logger;
      private readonly INewsService _NewsService;

      public NewsController(ILogger<NewsController> logger, INewsService newsService)
      {
            _logger = logger;
            _NewsService = newsService;
      }

      [HttpGet]
      public async Task<IActionResult> GetNewsAsync([FromQuery] int page,[FromQuery] int perPage)
      {
            _logger.LogInformation("get news: page - {page}, Per Page - {perPage}", page, perPage);
            var result = await _NewsService.GetNewsAsync(page, perPage);
            return Ok(result);
      }

      
      [HttpGet("find")]
      public async Task<IResult> FindNewsAsync([FromQuery] int page,[FromQuery] int perPage, [FromQuery] string? author = null, [FromQuery] string? keywords = null, [FromQuery]string?[] tags = null!)
      {
            if (!ModelState.IsValid)
            {
                  _logger.LogWarning("Invalid request");
                  return Results.BadRequest();
            }
            _logger.LogInformation("News find Page - {page}, Per page - {PerPage}", page, perPage);
            var result = await _NewsService.FindNewsAsync(page, perPage, author!, keywords!, tags!);
            return Results.Ok(result);
      }

      
      [HttpGet("user/{id}")]
      public async Task<IResult> FindNewsById(long id,[FromQuery]int page, [FromQuery] int PerPage)
      {
            var result = await _NewsService.FindNewsByIdAsync(id, page, PerPage);
            return Results.Ok(result);
      }


      [Authorize(Roles = "base")]
      [HttpPost]
      public async Task<IResult> PostNewsAsync(NewsDto dto)
      {
            if (!ModelState.IsValid)
            {
                  _logger.LogWarning("Invalid request");
                  return Results.BadRequest();
            }
            var userid = new Guid(HttpContext.User.FindFirstValue("userId")!);
            var result = await _NewsService.CreateNewsAsync(dto, userid);
            if (result.Success)
            {
                  _logger.LogInformation("added new news");
                  return Results.Ok(result);
            }
            return Results.BadRequest(result);
      }

      
      [Authorize(Roles = "base")]
      [HttpPut("{id}")]
      public async Task<IResult> PutNewsAsync(NewsDto dto,long? id)
      {
            if (!ModelState.IsValid)
            {
                  _logger.LogWarning("Invalid request for put");
                  return Results.BadRequest();
            }
            var userId = new Guid(HttpContext.User.FindFirstValue("userId")!);
            var result = await _NewsService.UpdateNewsAsync(id,dto,userId);
            return Results.Ok(result);
      }
      
      
      [Authorize(Roles = "base")]
      [HttpDelete("{id}")]
      public async Task<IResult> DeleteNewsById(long? id)
      {
            if (!ModelState.IsValid)
            {
                  _logger.LogWarning("Invalid request for delete");
                  return Results.BadRequest();
            }
            var result = await _NewsService.DeleteNewsAsync(id);
            return Results.Ok(result);
      }
}