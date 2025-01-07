using AutoMapper;
using FuelChampion.Api.Data;
using FuelChampion.Api.Models;

namespace FuelChampion.Api.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(DBContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
