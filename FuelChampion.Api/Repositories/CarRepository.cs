using AutoMapper;
using FuelChampion.Api.Data;
using FuelChampion.Library.Models;

namespace FuelChampion.Api.Repositories;

public class CarRepository : RepositoryBase<Car>, ICarRepository
{
    public CarRepository(DBContext context, IMapper mapper) : base(context, mapper) { }


}
