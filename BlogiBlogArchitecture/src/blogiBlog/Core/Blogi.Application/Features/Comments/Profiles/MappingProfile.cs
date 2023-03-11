using Blogi.Application.Features.Comments.Commands.Create;
using Blogi.Application.Features.Comments.Commands.Delete;
using Blogi.Application.Features.Comments.Commands.IsPublish;

namespace Blogi.Application.Features.Comments.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Comment, CreateCommentCommand>().ReverseMap();
            CreateMap<Comment, DeleteCommentCommand>().ReverseMap();
            CreateMap<Comment, IsPublishCommentCommand>().ReverseMap();
        }
    }
}