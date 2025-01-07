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
            ),voivodeships as
            (
                select distinct Voivodeship from dbo.GasStations
            ), PricePerLiterAvgPb95Cte as
            (
              select Voivodeship, cast(avg(PricePerLiter) as decimal(10,2)) as PricePerLiterAvg
              from invoices
              where FuelType = 1
              group by Voivodeship, FuelType
            ), PricePerLiterAvgPb98Cte as
            (
              select Voivodeship, cast(avg(PricePerLiter) as decimal(10,2)) as PricePerLiterAvg
              from invoices
              where FuelType = 2
              group by Voivodeship, FuelType
            ), PricePerLiterAvgLpgCte as
            (
              select Voivodeship, cast(avg(PricePerLiter) as decimal(10,2)) as PricePerLiterAvg
              from invoices
              where FuelType = 4
              group by Voivodeship, FuelType
            ), PricePerLiterAvgDieselCte as
            (
              select Voivodeship, cast(avg(PricePerLiter) as decimal(10,2)) as PricePerLiterAvg
              from invoices
              where FuelType = 8
              group by Voivodeship, FuelType
            ), avgPrices as
            (
                select 
                    v.Voivodeship
                   ,isnull(pb95.PricePerLiterAvg, 0) as PricePerLiterAvgPb95
                   ,isnull(pb98.PricePerLiterAvg, 0) as PricePerLiterAvgPb98 
                   ,isnull(diesel.PricePerLiterAvg, 0) as PricePerLiterAvgDiesel 
                   ,isnull(lpg.PricePerLiterAvg, 0) as PricePerLiterAvgLpg
                   from voivodeships as v
                left join PricePerLiterAvgPb95Cte as pb95 on pb95.Voivodeship = v.Voivodeship
                left join PricePerLiterAvgPb98Cte as pb98 on pb98.Voivodeship = v.Voivodeship
                left join PricePerLiterAvgDieselCte as diesel on diesel.Voivodeship = v.Voivodeship
                left join PricePerLiterAvgLpgCte as lpg on lpg.Voivodeship = v.Voivodeship
            )
            select * from avgPrices
        ").ToListAsync();

        return result;// _mapper.Map<List<GasStationAvgVoivodeshipPrice>>(result);
    }
}
