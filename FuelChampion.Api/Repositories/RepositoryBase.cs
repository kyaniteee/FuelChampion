using FuelChampion.Api.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FuelChampion.Api.Repositories;

public class RepositoryBase<T> where T : class
{
    protected readonly DbSet<T> _dbSet;
    protected readonly DBContext _context;

    public RepositoryBase(DBContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }
    public async Task<ICollection<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> filter, bool useNoTracking = false)
    {
        if (useNoTracking)
            return await _dbSet.AsNoTracking().Where(filter).FirstOrDefaultAsync();

        else
            return await _dbSet.Where(filter).FirstOrDefaultAsync();
    }

    public async Task<T> UpdateAsync(T dbRecord)
    {
        _dbSet.Update(dbRecord);
        await _context.SaveChangesAsync();

        return dbRecord;
    }

    public async Task<T> CreateAsync(T dbRecord)
    {
        _dbSet.Add(dbRecord);
        await _context.SaveChangesAsync();
        return dbRecord;
    }

    public async Task<bool> DeleteAsync(T dbRecord)
    {
        _dbSet.Remove(dbRecord);
        await _context.SaveChangesAsync();
        return true;
    }
}
