using Core.Application.FormAuth.ClaimInfo;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
namespace Core.Application.FormAuth.ClaimServices
{
    public class ClaimCoreService : IClaimCoreService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ClaimCoreService(IHttpContextAccessor _httpContextAccessor)
        {
            this._httpContextAccessor = _httpContextAccessor;
        }
        public async Task CreateAsync(ClaimCoreInfo claimInformations, string scheme)
        {
            // Create claims for user
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, claimInformations.UserId.ToString()),
                new Claim(ClaimTypes.Email, claimInformations.Email),
                new Claim(ClaimTypes.GivenName, claimInformations.FirstName ?? string.Empty),
                new Claim(ClaimTypes.Surname, claimInformations.LastName ?? string.Empty),
                

            };

            // Create principal for the current authentication scheme
            var userIdentity = new ClaimsIdentity(claims, scheme);
            var userPrincipal = new ClaimsPrincipal(userIdentity);

            // Set value indicating whether session is persisted and the time at which the authentication was issued
            var authenticationProperties = new AuthenticationProperties
            {
                IsPersistent = claimInformations.RememberMe,
                IssuedUtc = DateTime.UtcNow,
                ExpiresUtc = DateTime.UtcNow.AddHours(1),
            };

            await _httpContextAccessor.HttpContext.SignInAsync(scheme, userPrincipal, authenticationProperties);
        }

    }
}