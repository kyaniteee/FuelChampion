using AutoMapper;
using FuelChampion.Api.Data;
using FuelChampion.Library.Models;
using Microsoft.EntityFrameworkCore;

namespace FuelChampion.Api.Repositories;

public class InvoiceRepository : RepositoryBase<Invoice>, IInvoiceRepository
{
    public InvoiceRepository(DBContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<ICollection<Invoice>> GetAllByUserIdAsync(string userId)
    {
        return await _context.Invoices.Where(x => x.UserId.ToString() == userId).ToListAsync();
    }
}
