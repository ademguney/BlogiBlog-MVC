using Blogi.Application.Features.Categories.Dtos.Get;

namespace Blogi.Application.Features.Categories.Commands.Delete
{
    public class DeleteCategoryCommand : IRequest<BaseCommandResponse<GetCategoryOutput>>
    {
        public int Id { get; set; }
    }
}