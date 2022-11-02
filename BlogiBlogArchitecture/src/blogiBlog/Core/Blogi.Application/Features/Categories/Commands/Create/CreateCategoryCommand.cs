using Blogi.Application.Features.Categories.Dtos.Get;

namespace Blogi.Application.Features.Categories.Commands.Create
{
    public class CreateCategoryCommand : IRequest<BaseCommandResponse<GetCategoryOutput>>
    {
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
    }
}
