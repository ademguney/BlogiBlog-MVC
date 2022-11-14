using Blogi.Dashboard.FormAuth.ClaimInfo;

namespace Blogi.Dashboard.FormAuth.ClaimServices
{
    public interface IClaimService
    {
        Task CreateAsync(ClaimCoreInfo claimInformations, string scheme);
    }
}