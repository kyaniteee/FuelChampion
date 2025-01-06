using FuelChampion.Api.Data;
using FuelChampion.Api.Models;

namespace FuelChampion.Api.Repositories;

public class CarRepository : RepositoryBase<Car>, ICarRepository
{
    public CarRepository(DBContext context) : base(context) { }


}
