using Blogi.Application.Features.Languages.Dtos.Delete;

namespace Blogi.Application.Features.Languages.Commands.Delete
{
    public class DeleteLanguageCommand : IRequest<BaseCommandResponse<DeleteLanguageOutput>>
    {
        public int Id { get; set; }
    }
}
