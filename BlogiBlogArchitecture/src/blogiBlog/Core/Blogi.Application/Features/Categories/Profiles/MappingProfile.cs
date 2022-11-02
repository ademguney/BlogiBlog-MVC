using Blogi.Application.Features.Categories.Commands.Delete;
using Blogi.Application.Features.Categories.Dtos.Get;

namespace Blogi.Application.Features.Categories.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, GetCategoryOutput>().ReverseMap();

            CreateMap<Tag, DeleteCategoryCommand>().ReverseMap();
        }
    }
}