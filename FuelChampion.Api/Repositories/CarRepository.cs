using FuelChampion.Api.Data;
using FuelChampion.Library.Models;
using FuelChampion.Library.Repositories;

namespace FuelChampion.Api.Repositories;

public class CarRepository : RepositoryBase<Car>, ICarRepository
{
    private readonly FuelContext _dbContext;
    public CarRepository(FuelContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
