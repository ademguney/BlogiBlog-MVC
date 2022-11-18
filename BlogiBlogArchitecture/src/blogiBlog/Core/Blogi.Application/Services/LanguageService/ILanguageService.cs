using Blogi.Application.Features.Languages.Dtos.Get;
using Blogi.Application.Features.Languages.Dtos.GetList;

namespace Blogi.Application.Services.LanguageService
{
    public interface ILanguageService
    {
        Task<List<GetListLanguageOutput>> GetListAsync();
        Task<GetLanguageOutput> GetByCultureAsync(string culture);
    }
}