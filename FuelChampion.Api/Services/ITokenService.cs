namespace FuelChampion.Api.Services
{
    public interface ITokenService
    {
        string CreateToken(Library.Models.User user);
    }
}
