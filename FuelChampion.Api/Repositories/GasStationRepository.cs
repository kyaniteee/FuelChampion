using FuelChampion.Api.Data;
using FuelChampion.Api.Models;

namespace FuelChampion.Api.Repositories;

public class GasStationRepository : RepositoryBase<GasStation>, IGasStationRepository
{
    public GasStationRepository(DBContext context) : base(context)
    {
    }
}
