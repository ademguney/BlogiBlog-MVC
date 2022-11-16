using Blogi.Application.Features.Comment.Commands.CommentCreate;

namespace Blogi.Application.Features.Comment.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.Comment, CreateCommentCommand>().ReverseMap();          
        }
    }
}