using FuelChampion.Library.Models;

namespace FuelChampion.Api.Repositories;

public interface IInvoiceRepository : IRepositoryBase<Invoice>
{
    Task<ICollection<Invoice>> GetAllByUserIdAsync(string userId);
    Task<ICollection<InvoiceView>> GetInvoiceViewByUserId(string userId);
}
