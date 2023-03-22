using Blogi.Application.Features.Languages.Dtos.Get;

namespace Blogi.Application.Features.Languages.Queries.Get
{
    public class GetLanguageQuery : IRequest<BaseCommandResponse<GetLanguageOutput>>
    {
        public int? Id { get; set; }
        public string Culture { get; set; }
    }
}