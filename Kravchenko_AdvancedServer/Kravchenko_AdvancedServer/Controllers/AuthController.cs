using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.IdentityModel.Tokens;
using System.Text;
using Kravchenko_AdvancedServer.Models.DTOs;
using Kravchenko_AdvancedServer.Services;
using Microsoft.IdentityModel.Tokens;

namespace Kravchenko_AdvancedServer.Controllers;

[Route("auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService, ILogger<AuthController> logger)
    {
        _logger = logger;
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IResult> RegisterAsync(RegisterUserDto dto)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogWarning("bad request: register");
            return Results.BadRequest(ModelState);
        }
        else
        {
            _logger.LogInformation("continue register: user: {0}", dto.Email);
            var result = await _authService.RegisterAsync(dto);
            return Results.Ok(result);
        }
    }
    
    [HttpPost("login")]
    public async Task<IResult> LoginAsync(AuthDto dto)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogWarning("bad request: login");
            return Results.BadRequest(ModelState);
        }
        else
        {
            _logger.LogInformation("continue login: user: {0}", dto.Email);
            var result = await _authService.LoginAsync(dto.Email,dto.Password);
            return Results.Ok(result);
        }
    }


}