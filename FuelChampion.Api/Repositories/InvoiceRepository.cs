using AutoMapper;
using FuelChampion.Api.Data;
using FuelChampion.Library.Models;
using Microsoft.EntityFrameworkCore;

namespace FuelChampion.Api.Repositories;

public class InvoiceRepository : RepositoryBase<Invoice>, IInvoiceRepository
{
    public InvoiceRepository(DBContext context, IMapper mapper) : base(context, mapper) { }

    public async Task<ICollection<Invoice>> GetAllByUserIdAsync(string userId)
    {
        return await _context.Invoices.Where(x => x.UserId.ToString() == userId).ToListAsync();
    }

    public async Task<ICollection<InvoiceView>> GetInvoiceViewByUserId(string userId)
    {
        var result = await _context.InvoicesView.FromSqlRaw(@$"
           select 
              i.*
             ,gs.Voivodeship as GasStationVoivodeship
             ,gs.City as GasStationCity
             ,gs.[Address] as GasStationAddress
             ,gs.[Name] as GasStationName
             ,c.Producent as CarProducent
             ,c.Model as CarModel
             ,c.ProductionYear as CarProductionYear
             ,c.RegistrationNumber as CarRegistrationNumber
           from dbo.Invoices as i
           join dbo.GasStations as gs on gs.Id = i.GasStationId
           left join dbo.Cars as c on c.Id = i.CarId
        ").Where(x => x.UserId.ToString() == userId).ToListAsync();

        return result;
    }
}
