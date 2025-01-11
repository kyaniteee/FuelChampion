using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Xml.Linq;

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

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string token = await _localStorageService.GetItemAsStringAsync(LOCAL_STORAGE_KEY)!;
            if (string.IsNullOrEmpty(token))
                return await Task.FromResult(new AuthenticationState(anonymous));

            var (name, email) = GetClaims(token);
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email))
                return await Task.FromResult(new AuthenticationState(anonymous));

            var claims = SetClaimsPrincipal(name, email);
            if (claims is null)
                return await Task.FromResult(new AuthenticationState(anonymous));
            else
                return await Task.FromResult(new AuthenticationState(claims));

        }

        private static ClaimsPrincipal SetClaimsPrincipal(string name, string email)
        {
            if (name is null || email is null)
                return new ClaimsPrincipal();
            return new ClaimsPrincipal(new ClaimsIdentity(
                [
                    new(ClaimTypes.Name, name!),
                    new(ClaimTypes.Email, email!)
                ], "JwtAuth"));
        }

        private static (string, string) GetClaims(string jwtToken)
        {
            if (string.IsNullOrEmpty(jwtToken))
                return (null, null);

            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwtToken);

            var name = token.Claims.FirstOrDefault(_ => _.Type == ClaimTypes.Name)!.Value;
            var email = token.Claims.FirstOrDefault(_ => _.Type == ClaimTypes.Email)!.Value;
            return (name, email);
        }

        public async Task UpdateAuthenticationState(string jwtToken)
        {
            jwtToken = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6InVzZXJAZXhhbXBsZS5jb20iLCJnaXZlbl9uYW1lIjoidXNlciIsIm5iZiI6MTczNjYyMzA1NSwiZXhwIjoxNzM2NjQ4MjU1LCJpYXQiOjE3MzY2MjMwNTUsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjcyNjAiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo3MjYwIn0.6sLXeB3Aq71Xb0dQCxDUxec_eAUGipuRV9NIePogG2M5ILihlv1i2KWo2TGuy7KZoaBk6P32EKl4mD9jxAGjdA";
            var claims = new ClaimsPrincipal();
            if (!string.IsNullOrEmpty(jwtToken))
            {
                var (name, email) = GetClaims(jwtToken);
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email))
                    return;

                var setClaims = SetClaimsPrincipal(name, email);
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
