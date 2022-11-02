using Blogi.Application.Features.StringResources.Dtos.Get;

namespace Blogi.Application.Features.StringResources.Commands.Update
{
    public class UpdateStringResourceCommand : IRequest<BaseCommandResponse<GetStringResourceOutput>>
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}