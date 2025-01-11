using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace FuelChampion.Api.Services.User;
public interface IUserService
{
    ValueTask<ClaimsPrincipal> GetUserAsync();
    Task GetUserAsync(Task<AuthenticationState> task);
    void OnUserChanged(Task<AuthenticationState> task);
    Task GetChangedUserAsync(Task<AuthenticationState> task);
}
