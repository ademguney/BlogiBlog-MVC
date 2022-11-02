using Blogi.Application.Features.StringResources.Dtos.Delete;

namespace Blogi.Application.Features.StringResources.Commands.Delete
{
    public class DeleteStringResourceCommand : IRequest<BaseCommandResponse<DeleteStringResourceOutput>>
    {
        public int Id { get; set; }
    }
}