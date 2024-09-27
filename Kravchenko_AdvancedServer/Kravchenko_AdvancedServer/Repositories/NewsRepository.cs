using AutoMapper;
using Kravchenko_AdvancedServer.Models;
using Kravchenko_AdvancedServer.Models.DTOs;
using Kravchenko_AdvancedServer.Models.View;
using Microsoft.EntityFrameworkCore;

namespace Kravchenko_AdvancedServer.Repositories;

public class NewsRepository : INewsRepository
{
    AppDbContext _context;
    ILogger<NewsRepository> _logger;

    public NewsRepository(AppDbContext context, ILogger<NewsRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IEnumerable<News?>> GetNewsAsync(int pageNumber, int pageSize)
    {
        _logger.LogInformation("Repository: GetNewsAsync: getting all news");
        return await _context.News.Where(c => c.Id > pageNumber-1*pageSize).OrderByDescending(c => c.Id).Take(pageSize).ToListAsync();
    }

    public async Task<IEnumerable<News?>> FindNewsAsync(int pageNumber, int pageSize, string? author, string? keyword, string?[] tags)
    {
        string tag = "";
        var news = _context.News.Include(x => x.Tags).Include(x => x.User).AsQueryable();
        if (!string.IsNullOrEmpty(author))
        {
            _logger.LogInformation("Repository: FindNewsAsync: searching for author");
            news = news.Where(x => x.User.Name.ToLower().Contains(author.ToLower()));
        }
        if (!string.IsNullOrEmpty(keyword))
        {
            _logger.LogInformation("Repository: FindNewsAsync: searching for keyword");
            news = news.Where(x => x.Title.ToLower().Contains(keyword.ToLower()));
        }
        if (tags != null && tags.Length > 0)
        {
            _logger.LogInformation("Repository: FindNewsAsync: searching for tags");
            news = news.Where(x => x.Tags.Any(s=>tags.Contains(s.Title.ToLower())));
            tag = "Tag existing";
        }
        _logger.LogInformation("Repository: FindNewsAsync: searching news: parameters:{0},{1},{2}",author,keyword,tag);
        return await news.Where(c=>c.Id>pageNumber-1*pageSize).OrderByDescending(c=>c.Id).Take(pageSize).ToListAsync();
    }

    public async Task<IEnumerable<News?>> FindNewsByIdAsync(long newsId, int pageNumber, int pageSize)
    {
        _logger.LogInformation("Repository: FindNewsByIdAsync: searching for news by id");
        return await _context.News.Include(x=>x.Tags).Include(x=>x.User).AsNoTracking().Where(x=>x.Id == newsId && x.Id > pageNumber-1*pageSize)
            .OrderByDescending(x=>x.Id).Take(pageSize).ToListAsync();
    }

    public async Task<long?> CreateNewsAsync(NewsDto dto, Guid userId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
        if (user == null)
        {
            _logger.LogInformation("Repository: CreateNewsAsync: user not found");
            return null;
        }
        
        var news = new News
        {
            Image = dto.Image,
            Description = dto.Description,
            Title = dto.Title,
            User = user
        };
        if (news==null)
        {
            _logger.LogInformation("Repository: CreateNewsAsync: news not found");
            return null;
        }
        List<Tag> tags = dto.Tags.Select(x => new Tag { Title = x }).ToList();
        foreach (var tag in tags)
        {
            var checkTag = await _context.Tags.FirstOrDefaultAsync(x => x.Title == tag.Title);
            if (checkTag!=null)
            {
               checkTag.News.Add(news);
            }
            else
            {
                news.Tags.Add(tag);
            }
            
        }

        await _context.News.AddAsync(news);
        await _context.SaveChangesAsync();
        return news.Id;
    }

    public async Task<bool> PutNewsAsync(long? id, NewsDto dto, Guid userId)
    {
        var user = _context.Users.FirstOrDefault(x => x.Id == userId);
        if (user == null)
        {
            _logger.LogInformation("Repository: PutNewsAsync: user not found");
            return false;
        }

        var news = _context.News.Include(n=>n.Tags).FirstOrDefault(x => x.Id==id);
        if (news == null)
        {
            _logger.LogInformation("Repository: PutNewsAsync: news not found");
            return false;
        }

        news.Title = dto.Title;
        news.User = user;
        news.Description = dto.Description;
        
        foreach (var tag in  dto.Tags)
        {
            if (dto.Tags == null)
            {
                _logger.LogInformation("Repository: PutNewsAsync: tags not found");
            }

            var checkTag = await _context.Tags.FirstOrDefaultAsync(x => x.Title == tag);
            if (checkTag == null)
            {
                news.Tags.Add(new Tag { Title = tag });
            }
            else
            {
                {
                    if (!news.Tags.Any(x => x.Title == tag))
                    {
                        news.Tags.Add(checkTag);
                    }
                }
            }
            checkTag.News.Add(news);
        }
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task DeleteNewsAsync(long? id)
    {
        var news = _context.News.FirstOrDefault(x => x.Id == id)!;
        _logger.LogInformation("Repository: DeleteNewsAsync: delete existing news:{0}",id);
        _context.News.Remove(news);
        await _context.SaveChangesAsync();
    }
}