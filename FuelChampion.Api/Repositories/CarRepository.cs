using FuelChampion.Api.Data;
using FuelChampion.Library.Models;
using FuelChampion.Library.Repositories;

namespace FuelChampion.Api.Repositories;

public class CarRepository : RepositoryBase<Car>, ICarRepository
{
    public CarRepository(DBContext context) : base(context) { }


}
