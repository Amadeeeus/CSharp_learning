using System.Security.Claims;
using Kravchenko_AdvancedServer.Models.DTOs;
using Kravchenko_AdvancedServer.Models.Responses;
using Kravchenko_AdvancedServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kravchenko_AdvancedServer.Controllers;
[Authorize]
[Route("user")]
public class UserController:ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;


    public UserController(ILogger<UserController> logger, IUserService service)
    {
        _logger = logger;
        _userService = service;
    }


    [HttpGet]
    public async Task<IResult> GetAllUsersAsync()
    {
        _logger.LogInformation("Getting all users");
        var result = await _userService.GetAllUsersAsync();
        return Results.Ok(result);
    }


    [HttpGet("{id}")]
    public async Task<IResult> GetUserByIdAsync(Guid id)
    {
        var result = await _userService.GetUserByIdAsync(id);
        if (result.Success)
        {
            _logger.LogInformation("Getting user by id");
            return Results.Ok(result);
        }
        _logger.LogWarning("Bad request in user by id");
        return Results.BadRequest();
    }


    [HttpGet("info")]
    public async Task<IResult> GetCurrentUserInfoAsync()
    {
        var userId = new Guid(HttpContext.User.FindFirstValue("userId"));
        var result = await _userService.GetUserInfoAsync(userId);
        if (result.Success)
        {
            _logger.LogInformation("Getting current user info");
            return Results.Ok(result);
            
        }
        _logger.LogWarning("Bad request in user info");
        return Results.BadRequest(result);
    }

    [HttpPut]
    public async Task<IResult> PutUserAsync(PutUserDto dto)
    {
        var id = new Guid(HttpContext.User.FindFirstValue("userId"));
        var result = await _userService.PutUserAsync(dto,id);
        if (result.Success)
        {
            _logger.LogInformation("User:{1} Updated",dto.Name);
            return Results.Ok(result);
        }
        _logger.LogWarning("Bad request in user:{0} Update",dto.Name);
        return Results.BadRequest(result);
    }

    [HttpDelete]
    public async Task<IResult> DeleteUserAsync()
    {
        var id = new Guid(HttpContext.User.FindFirstValue("UserId"));
        var result = await _userService.DeleteUserAsync(id);
        if (result.Success)
        {
            _logger.LogInformation("user with id:{0} successfully deleted",id);
        }
        _logger.LogWarning("Bad request in user:{0} delete",id);
        return Results.BadRequest(result);
    }

}