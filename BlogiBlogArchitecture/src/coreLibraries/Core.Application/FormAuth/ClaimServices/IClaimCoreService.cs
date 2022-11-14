using Core.Application.FormAuth.ClaimInfo;

namespace Core.Application.FormAuth.ClaimServices
{
    public interface IClaimCoreService
    {
        Task CreateAsync(ClaimCoreInfo claimInformations, string scheme);
    }
}