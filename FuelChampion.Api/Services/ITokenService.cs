using FuelChampion.Library.Models;

namespace FuelChampion.Api.Services
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
