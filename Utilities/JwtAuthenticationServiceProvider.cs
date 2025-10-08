using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FEBookStoreManagement.Utilities;

public class JwtAuthenticationServiceProvider : AuthenticationStateProvider
{
    private readonly ILocalStorageService _localStorage;
    private readonly JwtSecurityTokenHandler _tokenHandler;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly NavigationManager _navigation;

    public JwtAuthenticationServiceProvider(ILocalStorageService localStorage, IHttpContextAccessor httpContextAccessor, NavigationManager navigation)
    {
        _localStorage = localStorage;
        _httpContextAccessor = httpContextAccessor;
        _navigation = navigation;

        _tokenHandler = new JwtSecurityTokenHandler();
    }

    // This is the core method Blazor calls to check the user's status.
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {

        // Check if we're prerendering (no JS runtime available yet)
        if (_httpContextAccessor.HttpContext != null && _httpContextAccessor.HttpContext.Response.HasStarted == false)
        {
            // Return anonymous user during prerender
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        // 1. Retrieve the token from local storage
        var savedToken = await _localStorage.GetItemAsStringAsync("token");

        if (string.IsNullOrWhiteSpace(savedToken))
        {
            // No token found, user is anonymous/not authenticated
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        try
        {
            // 2. Validate the token and check for expiration (basic check)
            var token = _tokenHandler.ReadJwtToken(savedToken);
            var expiryDate = token.ValidTo;

            if (expiryDate < DateTime.UtcNow)
            {
                // Token is expired, clear storage and treat as anonymous
                await MarkUserLoggedOut();
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            // 4. Create ClaimsPrincipal from the token's claims
            var identity = new ClaimsIdentity(token.Claims, "jwtAuthType");
            var principal = new ClaimsPrincipal(identity);

            // 5. Return the authenticated state
            return new AuthenticationState(principal);
        }
        catch
        {
            // Token is invalid/corrupt, treat as anonymous
            await MarkUserLoggedOut();
            await RedirectToLogin();
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }
    }

    // Method to call after a successful login
    public async Task MarkUserAsLoggedIn(string token)
    {
        await _localStorage.SetItemAsStringAsync("token", token);

        // Notify the framework the authentication state has changed
        var authState = Task.FromResult(await GetAuthenticationStateAsync());
        NotifyAuthenticationStateChanged(authState);
    }

    // Method to call for logout
    public async Task MarkUserLoggedOut()
    {
        await _localStorage.RemoveItemAsync("token");

        // Notify the framework the user is now anonymous
        var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
        var authState = Task.FromResult(new AuthenticationState(anonymousUser));
        NotifyAuthenticationStateChanged(authState);
    }

    private async Task RedirectToLogin()
    {
        // Delay slightly to ensure navigation is safe (no interop errors)
        await Task.Delay(50);
        _navigation.NavigateTo("/login", true);
    }
}