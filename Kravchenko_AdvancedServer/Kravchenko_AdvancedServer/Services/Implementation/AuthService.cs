using Kravchenko_AdvancedServer.Models.DTOs;
using Kravchenko_AdvancedServer.Models.Responses;
using Kravchenko_AdvancedServer.Repositories;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using Kravchenko_AdvancedServer.Models;

namespace Kravchenko_AdvancedServer.Services;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtProvider _jwtProvider;
    private readonly IMapper _mapper;
    private readonly ILogger<AuthService> _logger;

    public AuthService(
        IAuthRepository repository,
        IPasswordHasher passwordHasher,
        IJwtProvider jwtProvider,
        IMapper mapper,
        ILogger<AuthService> logger)
    {
        _authRepository = repository;
        _passwordHasher = passwordHasher;
        _jwtProvider = jwtProvider;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<CustomSuccessResponse<LoginUserDto>> RegisterAsync(RegisterUserDto dto)
    {
        var userMap = _mapper.Map<User>(dto);
        var hashPassword = _passwordHasher.HashingPassword(dto.Password);
        userMap.Password = hashPassword;
        var checkUser = await _authRepository.GetUserAsync(dto.Email);
        
        if (checkUser != null)
        {
           _logger.LogWarning("User {0} already exists", dto.Email);
            return new CustomSuccessResponse<LoginUserDto>()
            {
                Success = false,
                StatusCode = StatusCodes.Status400BadRequest,
            }; 
        }
        
        var registerMap = _mapper.Map<LoginUserDto>(await _authRepository.AddUserAsync(userMap));
        registerMap.Token = _jwtProvider.GenerateToken(registerMap.Id, registerMap.Role);
        return new CustomSuccessResponse<LoginUserDto>()
        {
            Success = true,
            StatusCode = StatusCodes.Status200OK,
            Data = registerMap
        };
    }

    public async Task<CustomSuccessResponse<LoginUserDto>> LoginAsync(string email, string password)
    {
        var checkUser = await _authRepository.GetUserAsync(email);
        
        if (checkUser == null)
        {
            _logger.LogWarning("User with email:{0} does not exist", email);
            return new CustomSuccessResponse<LoginUserDto>()
            {
                Success = false,
                StatusCode = StatusCodes.Status400BadRequest
            };
        }

        if (!_passwordHasher.PasswordVerification(password, checkUser.Password))
        {
            _logger.LogWarning("Invalid password for user with email:{0}", email);
            return new CustomSuccessResponse<LoginUserDto>()
            {
                Success = false,
                StatusCode = StatusCodes.Status400BadRequest
            };
        }
        
        var loggedUser = _mapper.Map<LoginUserDto>(checkUser);
        loggedUser.Token = _jwtProvider.GenerateToken(loggedUser.Id, loggedUser.Role);
        return new CustomSuccessResponse<LoginUserDto>()
        {
            Success = true,
            StatusCode = StatusCodes.Status200OK,
            Data = loggedUser
        };
    }
}
