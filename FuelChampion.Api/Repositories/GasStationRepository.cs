using FuelChampion.Api.Data;
using FuelChampion.Library.Models;
using FuelChampion.Library.Repositories;

namespace FuelChampion.Api.Repositories;

public class GasStationRepository : RepositoryBase<GasStation>, IGasStationRepository
{
    public GasStationRepository(DBContext context) : base(context)
    {
    }
}
