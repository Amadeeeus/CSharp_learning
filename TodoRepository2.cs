using Microsoft.EntityFrameworkCore;

namespace TodoApi.Repository;

public class TodoRepository2
{
    private readonly AppDbContext _context;

    public TodoRepository2(AppDbContext context)
    {
        _context = context;
    }

    public async Task Create(TaskEntity entity)
    {
        _context.Entities.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<TaskEntity>> GetPaginated(int pageNumber, int pageSize, bool? status)
    {
        IQueryable<TaskEntity> query = _context.Entities;
        if (status.HasValue)
        {
            query = query.Where(n => n.Status == status.Value);
        }
        return await query.Skip((pageNumber -1)*pageSize).Take(pageSize).ToListAsync();
    }

    public async Task Delete()
    {
        _context.Entities.Where(n => n.Status == true).ExecuteDelete();
        await _context.SaveChangesAsync();
    }

    public async Task DeleteId(int id)
    {
        await _context.Entities.Where(n => n.Id == id).ExecuteDeleteAsync();
        await _context.SaveChangesAsync();
    }
    
    public async Task PatchStatusAll(bool? status)
    {
      await  _context.Entities.Where(n => n.Status != status).ExecuteUpdateAsync(n=>n.SetProperty(x=>x.Status,status).SetProperty(x=>x.UpdatedAt,DateTime.UtcNow));
      await _context.SaveChangesAsync();
    }

    public async Task PatchStatus(long id, bool? status)
    {
       await _context.Entities.Where(n => n.Id == id).ExecuteUpdateAsync(x =>
            x.SetProperty(c => c.Status, status).SetProperty(c => c.UpdatedAt, DateTime.UtcNow));
       await _context.SaveChangesAsync();
    }

    public async Task PatchText(long id, string text)
    {
        await _context.Entities.Where(x => x.Id == id).ExecuteUpdateAsync(x =>
            x.SetProperty(c => c.Text, text).SetProperty(c => c.UpdatedAt, DateTime.UtcNow));
        await _context.SaveChangesAsync();
    }

}