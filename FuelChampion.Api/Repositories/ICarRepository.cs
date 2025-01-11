using FuelChampion.Library.Models;


namespace FuelChampion.Api.Repositories;

public interface ICarRepository : IRepositoryBase<Car>
{
    Task<ICollection<Car>> GetAllByUserIdAsync(string userId);
}
