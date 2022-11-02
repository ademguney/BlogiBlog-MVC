using Blogi.Application.Features.Categories.Dtos.Get;

namespace Blogi.Application.Features.Categories.Queries.Get
{
    public class GetCategoryQuery : IRequest<BaseCommandResponse<GetCategoryOutput>>
    {
        public int Id { get; set; }
    }
}