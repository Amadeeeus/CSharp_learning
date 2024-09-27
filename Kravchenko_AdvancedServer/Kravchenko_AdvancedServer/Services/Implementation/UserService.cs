using AutoMapper;
using Kravchenko_AdvancedServer.Models;
using Kravchenko_AdvancedServer.Models.DTOs;
using Kravchenko_AdvancedServer.Models.Responses;
using Kravchenko_AdvancedServer.Models.View;
using Kravchenko_AdvancedServer.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace Kravchenko_AdvancedServer.Services;
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<UserService> _logger;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userReposutory, ILogger<UserService> logger, IMapper mapper)
    {
        _userRepository = userReposutory;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<CustomSuccessResponse<List<PublicUserView>>> GetAllUsersAsync()
    {
        var result = _mapper.Map<List<PublicUserView>>(await _userRepository.GetAllUsersAsync());
        _logger.LogInformation("Getting users....");
        return new CustomSuccessResponse<List<PublicUserView>>()
        {
            Success = true,
            StatusCode = StatusCodes.Status200OK,
            Data = result
        };
    }

    public async Task<CustomSuccessResponse<PublicUserView>> GetUserInfoAsync(Guid userId)
    {
        if (userId == Guid.Empty)
        {
            _logger.LogWarning("User id is cant be empty.");
            return new CustomSuccessResponse<PublicUserView>()
            {
                Success = false,
                StatusCode = StatusCodes.Status400BadRequest
            };
        }
 
        var result = _mapper.Map<PublicUserView>(await _userRepository.GetUserInfoAsync(userId));
        _logger.LogInformation("Getting user{0} info...", userId);
        return new CustomSuccessResponse<PublicUserView>()
        {
            Success = true,
            StatusCode = StatusCodes.Status200OK,
            Data = result
        };
    }

    public async Task<CustomSuccessResponse<PublicUserView>> GetUserByIdAsync(Guid id)
    {
        if (id == Guid.Empty || await _userRepository.GetUserByIdAsync(id) is null)
        {
            _logger.LogWarning("user with id:{0} not found",id);
            return new CustomSuccessResponse<PublicUserView>()
            {
                Success = false,
                StatusCode = StatusCodes.Status404NotFound,
            };
        }

        var result =_mapper.Map<PublicUserView>(await _userRepository.GetUserByIdAsync(id));
        
        _logger.LogInformation("Getting user{0} info... method GetUserById", id);
        return new CustomSuccessResponse<PublicUserView>()
        {
            Success = true,
            StatusCode = StatusCodes.Status200OK,
            Data = result
        };
    }

    public async Task<CustomSuccessResponse<PutUserDtoResponse>> PutUserAsync(PutUserDto dto, Guid userId)
    {
        if (dto.Email == null)
        {
            _logger.LogWarning("PutUserAsync: Email is null");
            return new CustomSuccessResponse<PutUserDtoResponse>()
            {
                Success = false,
                StatusCode = StatusCodes.Status400BadRequest
            };
        }

        if (await _userRepository.GetUserByEmailAsync(dto.Email) is not null)
        {
            _logger.LogWarning("PutUserAsync: Email already exist");
            return new CustomSuccessResponse<PutUserDtoResponse>()
            {
                Success = false,
                StatusCode = StatusCodes.Status400BadRequest
            };
        }
        _logger.LogInformation("PutUserAsync: Updating users");
        var result = _mapper.Map<PutUserDtoResponse>(await _userRepository.PutUserAsync(dto, userId));
        return new CustomSuccessResponse<PutUserDtoResponse>()
        {
            Success = true,
            StatusCode = StatusCodes.Status200OK,
            Data = result
        };

    }

    public async Task<BaseSuccessResponse> DeleteUserAsync(Guid id)
    {
        if(id==Guid.Empty)
        {
            _logger.LogWarning("DeleteUserAsync: Id is null");
            return new BaseSuccessResponse()
            {
                Success = false,
                StatusCode = StatusCodes.Status400BadRequest,
            };
        }
        _logger.LogInformation("DeleteUserAsync: Deleting user");
        await _userRepository.DeleteUserAsync(id);
        return new BaseSuccessResponse()
        {
            Success = true,
            StatusCode = StatusCodes.Status200OK
        };
    }

}