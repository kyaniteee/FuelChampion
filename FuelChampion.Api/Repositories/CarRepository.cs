using AutoMapper;
using FuelChampion.Api.Data;
using FuelChampion.Library.Models;
using Microsoft.EntityFrameworkCore;

namespace FuelChampion.Api.Repositories;

public class CarRepository : RepositoryBase<Car>, ICarRepository
{
    public CarRepository(DBContext context, IMapper mapper) : base(context, mapper) { }

    public async Task<ICollection<Car>> GetAllByUserIdAsync(string userId)
    {
        return await _context.Cars.Where(x => x.UserId.ToString() == userId).ToListAsync();
    }
}
