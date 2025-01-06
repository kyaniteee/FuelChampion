using FuelChampion.Api.Data;
using FuelChampion.Api.Models;
using FuelChampion.Library.Repositories;

namespace FuelChampion.Api.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(DBContext context) : base(context)
    {
    }
}
