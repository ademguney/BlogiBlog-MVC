using Blogi.Application.Features.Abouts.Dtos.Get;

namespace Blogi.Application.Features.Abouts.Queries.Get
{
    public class GetAboutQuery : IRequest<BaseCommandResponse<GetAboutOutput>>
    {
        public int Id { get; set; }
    }
}