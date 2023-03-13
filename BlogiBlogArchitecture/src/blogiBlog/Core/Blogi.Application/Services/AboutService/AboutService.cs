using Blogi.Application.Features.Abouts.Dtos.Get;
using Blogi.Application.Features.Abouts.Dtos.GetList;
using Blogi.Application.Repositories.PostRepository;
using Blogi.Domain.Entities;

namespace Blogi.Application.Services.AboutService
{
    public class AboutService : IAboutService
    {
        private readonly IMapper _mapper;
        private readonly IAboutReadRepository _aboutReadRepository;
        private readonly IAboutWriteRepository _aboutWriteRepository;
        private readonly IVisitorInformationService _visitorInformationService;

        public AboutService(
            IMapper mapper,
            IAboutReadRepository aboutReadRepository,
            IAboutWriteRepository aboutWriteRepository,
            IVisitorInformationService visitorInformationService
            )
        {
            _mapper = mapper;
            _aboutReadRepository = aboutReadRepository;
            _aboutWriteRepository = aboutWriteRepository;
            _visitorInformationService = visitorInformationService;
        }

        public async Task<GetAboutOutput> GetAsync(int id, string culture)
        {
            var result = new About();

            if (id > 0)
                result = await _aboutReadRepository.GetAsync(x => x.Id == id);

            if (!string.IsNullOrEmpty(culture))
            {
                result = await _aboutReadRepository
                        .GetAll(x => x.Languages.Culture.Trim().ToLower() == culture.Trim().ToLower())
                        .Include(x => x.Languages)
                        .FirstOrDefaultAsync();

                #region Visitor Information

                var ipAddress = GetIpAddress.GetIpAddres();
                var visitor = await _visitorInformationService.GetAsync(ipAddress, result.Slug);
                if (!visitor)
                {
                    result.CountOfView++;
                    _aboutWriteRepository.Update(result);
                    await _visitorInformationService.AddAsync(ipAddress, result.Slug);
                }

                #endregion
            }

            var resultMapp = _mapper.Map<GetAboutOutput>(result);
            return resultMapp;
        }

        public async Task<List<GetListAboutOutput>> GetListAsync()
        {
            return await _aboutReadRepository.GetAll().Include(x => x.Languages).Select(x => new GetListAboutOutput
            {
                Id = x.Id,
                LanguageName = x.Languages.Name,
                Title = x.Title,
                Slug = x.Slug
            }).ToListAsync();
        }
    }
}