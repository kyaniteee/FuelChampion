using FuelChampion.Api.Models;

namespace FuelChampion.Api.Services
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
