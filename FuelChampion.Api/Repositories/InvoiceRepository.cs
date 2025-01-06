using FuelChampion.Api.Data;
using FuelChampion.Library.Models;
using FuelChampion.Library.Repositories;

namespace FuelChampion.Api.Repositories;

public class InvoiceRepository : RepositoryBase<Invoice>, IInvoiceRepository
{
    public InvoiceRepository(DBContext context) : base(context)
    {
    }
}
