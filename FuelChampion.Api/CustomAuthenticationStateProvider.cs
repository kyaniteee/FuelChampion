using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace FuelChampion.Api;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        // Sprawdź, czy użytkownik jest zalogowany
        var identity = new ClaimsIdentity(); // Pusty oznacza niezalogowanego użytkownika
                                             // Możena tu dodać logikę np. sprawdzenia tokenu JWT

        return Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));
    }

    public void NotifyUserAuthentication(string userName)
    {
        var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, userName) }, "auth");
        var user = new ClaimsPrincipal(identity);
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
    }

    public void NotifyUserLogout()
    {
        var identity = new ClaimsIdentity();
        var user = new ClaimsPrincipal(identity);
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
    }
}