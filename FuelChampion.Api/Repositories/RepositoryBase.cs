using FuelChampion.Api.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FuelChampion.Api.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly FuelContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public RepositoryBase(FuelContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
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
            await _dbContext.SaveChangesAsync();

            return dbRecord;
        }

        public async Task<T> CreateAsync(T dbRecord)
        {
            _dbSet.Add(dbRecord);
            await _dbContext.SaveChangesAsync();
            return dbRecord;
        }

        public async Task<bool> DeleteAsync(T dbRecord)
        {
            _dbSet.Remove(dbRecord);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
