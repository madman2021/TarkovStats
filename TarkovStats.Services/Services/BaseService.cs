using Microsoft.EntityFrameworkCore;
using TarkovStats.Repo;

namespace TarkovStats.Services.Services;

public abstract class BaseService<T> : IBaseService<T> where T: class
{
    protected readonly TarkovStatsContext _context;

    public BaseService(TarkovStatsContext context)
    {
        _context = context;
    }
    public async Task<T?> GetById(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<bool> SaveChanges()
    {
        try
        {
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            // ignored
        }

        return false;
    }
}