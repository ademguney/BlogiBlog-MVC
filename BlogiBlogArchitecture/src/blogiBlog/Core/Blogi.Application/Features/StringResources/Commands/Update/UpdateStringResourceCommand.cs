using Blogi.Application.Features.StringResources.Dtos.Update;

namespace Blogi.Application.Features.StringResources.Commands.Update
{
    public class UpdateStringResourceCommand : IRequest<BaseCommandResponse<UpdateStringResourceOutput>>
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
