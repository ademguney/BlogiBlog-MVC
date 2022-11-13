using Core.Application.FormAuth.ClaimInfo;

namespace Core.Application.FormAuth.ClaimServices
{
    public interface IClaimService
    {
        Task CreateAsync(ClaimCoreInfo claimInformations, string scheme);
    }
}