using Blogi.Application.Features.Categories.Commands.Create;
using Blogi.Application.Features.Categories.Commands.Delete;
using Blogi.Application.Features.Categories.Commands.Update;
using Blogi.Application.Features.Categories.Dtos.Get;

namespace Blogi.Application.Features.Categories.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, GetCategoryOutput>().ReverseMap();
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, DeleteCategoryCommand>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
        }
    }
}