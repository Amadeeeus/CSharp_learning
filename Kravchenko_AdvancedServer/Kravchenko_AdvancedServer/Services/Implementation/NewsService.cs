using AutoMapper;
using Kravchenko_AdvancedServer.Models;
using Kravchenko_AdvancedServer.Models.DTOs;
using Kravchenko_AdvancedServer.Models.Responses;
using Kravchenko_AdvancedServer.Models.View;
using Kravchenko_AdvancedServer.Repositories;

namespace Kravchenko_AdvancedServer.Services;

public class NewsService : INewsService
{
    private readonly ILogger<NewsService> _logger;
    private readonly INewsRepository _newsRepository;
    private readonly IMapper _mapper;

    public NewsService(ILogger<NewsService> logger, INewsRepository newsRepository, IMapper mapper)
    {
        _logger = logger;
        _newsRepository = newsRepository;
        _mapper = mapper;
    }

    public async Task<CustomSuccessResponse<PageableResponse<List<GetNewsOutDto>>>> GetNewsAsync(int pageNumber,
        int pageSize)
    {
        if (pageSize <= 0 || pageNumber <= 0)
        {
            _logger.LogWarning("GETNEWS: Count pages or count it can't be equal zero.Method");
            return new CustomSuccessResponse<PageableResponse<List<GetNewsOutDto>>>()
            {
                Success = false,
                StatusCode = StatusCodes.Status400BadRequest
            };
        }
        var result =await _newsRepository.GetNewsAsync(pageNumber, pageSize);
        _logger.LogInformation($"Page {pageNumber} of {pageSize} returned.");
        var convertedResult = _mapper.Map<List<GetNewsOutDto>>(result);
        var pageableResponse = new PageableResponse<List<GetNewsOutDto>>
        {
            Content = convertedResult,
            NumberOfElements = pageSize
        };
        return new CustomSuccessResponse<PageableResponse<List<GetNewsOutDto>>>()
        {
            Success = true,
            StatusCode = StatusCodes.Status200OK,
            Data = pageableResponse
        };
    }

    public async Task<CustomSuccessResponse<PageableResponse<List<GetNewsOutDto>>>> FindNewsAsync(int pageNumber,
        int pageSize, string? author, string? keyword, string?[] tags)
    {
        if (pageSize <= 0 || pageNumber <= 0)
        {
            _logger.LogWarning("FIND: Count pages or count it can't be equal zero.");
            return new CustomSuccessResponse<PageableResponse<List<GetNewsOutDto>>>()
            {
                Success = false,
                StatusCode = StatusCodes.Status400BadRequest
            };
        }
        var result = await _newsRepository.FindNewsAsync(pageNumber, pageSize,author!,keyword!,tags!);
        var convert = _mapper.Map<List<GetNewsOutDto>>(result);
        var pageableResponse = new PageableResponse<List<GetNewsOutDto>>
        {
            Content = convert,
            NumberOfElements = pageSize
        };
        _logger.LogInformation($"Page {pageNumber} of {pageSize} returned.");
        return new CustomSuccessResponse<PageableResponse<List<GetNewsOutDto>>>()
        {
            Success = true,
            StatusCode = StatusCodes.Status200OK,
            Data = pageableResponse
        };
    }

    public async Task<CustomSuccessResponse<PageableResponse<List<GetNewsOutDto>>>> FindNewsByIdAsync(long newsId,
        int pageNumber, int pageSize)
    {
        if (newsId == 0| pageNumber <= 0 || pageSize < 0)
        {
            _logger.LogWarning("FINDBYID: input parameters are invalid or equal zero.");
            return new CustomSuccessResponse<PageableResponse<List<GetNewsOutDto>>>()
            {
                Success = false,
                StatusCode = StatusCodes.Status400BadRequest
            };
        }
        _logger.LogInformation($"Page {pageNumber} of {pageSize} returned.");

        var result = await _newsRepository.FindNewsByIdAsync(newsId, pageNumber, pageSize); 
        var convert = _mapper.Map<List<GetNewsOutDto>>(result);
        var pageableResponse = new PageableResponse<List<GetNewsOutDto>>
        {
            Content = convert,
            NumberOfElements = pageSize
        };
        return new CustomSuccessResponse<PageableResponse<List<GetNewsOutDto>>>()
        {
            Success = true,
            StatusCode = StatusCodes.Status200OK,
            Data = pageableResponse
        };
    }

    public async Task<CreateNewSuccessResponse>CreateNewsAsync(NewsDto? newsDto, Guid userId)
    {
        if (newsDto is null || userId == Guid.Empty)
        {
            _logger.LogWarning("CREATENEWS: input parameters are invalid.");
            return new CreateNewSuccessResponse()
            {
                Success = false,
                StatusCode = StatusCodes.Status400BadRequest
            };
        }
        await _newsRepository.CreateNewsAsync(newsDto, userId);
        return new CreateNewSuccessResponse()
        {
            Success = true,
            StatusCode = StatusCodes.Status201Created,
            Id =  userId
        };
    }

    public async Task<BaseSuccessResponse> UpdateNewsAsync(long? id, NewsDto? newsDto, Guid userId)
    {
        if (newsDto is null || userId == Guid.Empty || id == 0)
        {
            _logger.LogWarning("PUTNEWS: input parameters are invalid.");
            return new BaseSuccessResponse()
            {
                Success = false,
                StatusCode = StatusCodes.Status400BadRequest
            };
        }
        _logger.LogInformation($"PUTNEWS: Updating news.");
        await _newsRepository.PutNewsAsync(id, newsDto, userId);
        return new BaseSuccessResponse()
        {
            Success = true,
            StatusCode = StatusCodes.Status201Created
        };
    }

    public async Task<BaseSuccessResponse> DeleteNewsAsync(long? id)
    {
        if (id == 0)
        {
            _logger.LogWarning("DELETE: input parameters are invalid.");
            return new BaseSuccessResponse()
            {
                Success = false,
                StatusCode = StatusCodes.Status400BadRequest
            };
        }
        _logger.LogInformation($"DELETE: Deleting news.");
        await _newsRepository.DeleteNewsAsync(id);
        return new BaseSuccessResponse()
        {
            Success = true,
            StatusCode = StatusCodes.Status200OK
        };
    }

}