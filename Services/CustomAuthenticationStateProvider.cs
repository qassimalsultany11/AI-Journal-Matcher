using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Security.Claims;

namespace AIJOURNALMATCHERWEB.Services
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IJSRuntime _js;

        public CustomAuthenticationStateProvider(IJSRuntime js)
        {
            _js = js;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // قراءة التوكن من المتصفح
            var token = await _js.InvokeAsync<string>("localStorage.getItem", "authToken");

            // إذا لم يكن هناك توكن، اعتبره غير مسجل
            if (string.IsNullOrEmpty(token))
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            // إذا كان هناك توكن، اعتبره مسجل
            var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, "User") }, "CustomAuth");
            return new AuthenticationState(new ClaimsPrincipal(identity));
        }

        public void MarkUserAsAuthenticated(string email)
        {
            var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, email) }, "CustomAuth"));
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(authenticatedUser)));
        }

        public void MarkUserAsLoggedOut()
        {
            var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymousUser)));
        }
    }
}