using FuelChampion.Library.Models.Gas;

namespace FuelChampion.Api.Repositories;

public interface IGasStationRepository : IRepositoryBase<GasStation>
{
    Task<ICollection<GasStationAvgVoivodeshipPrice>> GetAvgVoivodeshipPrices();
}
