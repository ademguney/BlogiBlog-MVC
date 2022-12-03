using Blogi.Application.Features.Abouts.Dtos.Get;
using Blogi.Application.Features.Abouts.Dtos.GetList;

namespace Blogi.Application.Services.AboutService
{
    public interface IAboutService
    {
        Task<GetAboutOutput> GetAsync(int id, string culture);
        Task<List<GetListAboutOutput>> GetListAsync();
    }
}