using Core.Application.FormAuth.ClaimInfo;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Core.Application.FormAuth.ClaimServices
{
    public class ClaimService : IClaimService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClaimService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateAsync(ClaimCoreInfo claimInformations, string scheme)
        {
            // Create claims for user
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, claimInformations.UserId.ToString()),
                new Claim(ClaimTypes.Email, claimInformations.Email),
                new Claim(ClaimTypes.GivenName, claimInformations.FirstName ?? string.Empty),
                new Claim(ClaimTypes.Surname, claimInformations.LastName ?? string.Empty)
            };

            // Create principal for the current authentication scheme
            var userIdentity = new ClaimsIdentity(claims, scheme);
            var userPrincipal = new ClaimsPrincipal(userIdentity);

            // Set value indicating whether session is persisted and the time at wich authentication was issued
            var authenticationProperties = new AuthenticationProperties
            {
                IsPersistent = claimInformations.RememberMe,
                IssuedUtc = DateTime.UtcNow,
                ExpiresUtc = DateTime.UtcNow
            };

            await _httpContextAccessor.HttpContext.SignInAsync(scheme, userPrincipal, authenticationProperties);
        }
    }
}