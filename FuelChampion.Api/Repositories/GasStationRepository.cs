using AutoMapper;
using FuelChampion.Api.Data;
using FuelChampion.Api.Models.Gas;
using Microsoft.EntityFrameworkCore;

namespace FuelChampion.Api.Repositories;

public class GasStationRepository : RepositoryBase<GasStation>, IGasStationRepository
{
    public GasStationRepository(DBContext context, IMapper mapper) : base(context, mapper) { }

    public async Task<ICollection<GasStationAvgVoivodeshipPrice>> GetAvgVoivodeshipPrices()
    {
        var result = await _context.GasStationAvgVoivodeshipPrices.FromSqlRaw(@$"
            with gasStations as
            (
            	select Id, Voivodeship from dbo.GasStations group by Id, Voivodeship
            )
            ,invoices as
            (
            	select 
            	i.*, gs.Voivodeship 
            	from dbo.Invoices as i
            	left join gasStations as gs on gs.Id = i.GasStationId
            )
            select 
              Voivodeship
             ,FuelType
             ,cast(avg(PricePerLiter) as decimal(10,2)) as PricePerLiterAvg
            from invoices
            group by Voivodeship, FuelType
        
        ").ToListAsync();

        return result;// _mapper.Map<List<GasStationAvgVoivodeshipPrice>>(result);
    }
}
