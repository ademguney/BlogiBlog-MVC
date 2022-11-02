using Blogi.Application.Features.Categories.Dtos.Get;

namespace Blogi.Application.Features.Categories.Commands.Update
{
    public class UpdateCategoryCommand : IRequest<BaseCommandResponse<GetCategoryOutput>>
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }       
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
    }
}