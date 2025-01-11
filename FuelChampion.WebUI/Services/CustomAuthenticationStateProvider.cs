using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FuelChampion.WebUI.Services
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private const string LOCAL_STORAGE_KEY = "auth";
        private readonly ClaimsPrincipal anonymous = new(new ClaimsIdentity());
        private readonly ILocalStorageService _localStorageService;

        public CustomAuthenticationStateProvider(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public async Task<Guid> GetUserId()
        {
            var authState = await GetAuthenticationStateAsync();
            var user = authState.User;

            if (user.Identity != null && user.Identity.IsAuthenticated)
            {
                // Pobieranie GUID z claimów użytkownika
                var userIdClaim = user.Claims.ToArray()[2]; // Claim "sub" często przechowuje identyfikator użytkownika
                if (userIdClaim != null)
                {
                    return Guid.Parse(userIdClaim.Value);
                }
            }

            throw new Exception("Not authorized");
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string jwtToken = await _localStorageService.GetItemAsStringAsync(LOCAL_STORAGE_KEY)!;
            if (string.IsNullOrEmpty(jwtToken))
                return await Task.FromResult(new AuthenticationState(anonymous));

            var (name, email, guid) = GetClaims(jwtToken);
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email))
                return await Task.FromResult(new AuthenticationState(anonymous));

            var claims = SetClaimsPrincipal(name, email, guid);
            if (claims is null)
                return await Task.FromResult(new AuthenticationState(anonymous));
            else
                return await Task.FromResult(new AuthenticationState(claims));

        }

        private ClaimsPrincipal SetClaimsPrincipal(string name, string email, string guid)
        {
            if (name is null || email is null || guid is null)
                return new ClaimsPrincipal();
            return new ClaimsPrincipal(new ClaimsIdentity(
                [
                    new(ClaimTypes.Name, name!),
                    new(ClaimTypes.Email, email!),
                    new(ClaimTypes.Authentication, guid!),
                ], "JwtAuth"));
        }

        private (string, string, string) GetClaims(string jwtToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwtToken);

            var name = token.Claims.FirstOrDefault(x => x.Type == "given_name")!.Value;
            var email = token.Claims.FirstOrDefault(x => x.Type == "email")!.Value;
            var guid = token.Claims.FirstOrDefault(x => x.Type == "sub")!.Value;
            return (name, email, guid);
        }

        public async Task UpdateAuthenticationState(string jwtToken)
        {
            var claims = new ClaimsPrincipal();
            if (!string.IsNullOrEmpty(jwtToken))
            {
                var (name, email, guid) = GetClaims(jwtToken);
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email))
                    return;

                var setClaims = SetClaimsPrincipal(name, email, guid);
                if (setClaims is null)
                    return;

                await _localStorageService.SetItemAsStringAsync(LOCAL_STORAGE_KEY, jwtToken);
            }
            else
            {
                await _localStorageService.RemoveItemAsync(LOCAL_STORAGE_KEY);
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claims)));
        }
    }
}
