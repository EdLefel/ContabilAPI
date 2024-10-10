using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        // Estado anônimo padrão
        return Task.FromResult(new AuthenticationState(_anonymous));
    }

    public void MarkUserAsAuthenticated(string nomeUser)
    {
        var identity = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, nomeUser)
        }, "apiauth_type");

        var user = new ClaimsPrincipal(identity);
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
    }

    public void MarkUserAsLoggedOut()
    {
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_anonymous)));
    }
}

