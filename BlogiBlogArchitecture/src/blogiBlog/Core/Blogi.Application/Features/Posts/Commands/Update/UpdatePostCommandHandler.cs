using Blogi.Application.Features.Posts.Dtos.Get;

namespace Blogi.Application.Features.Posts.Commands.Update
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, BaseCommandResponse<GetPostOutput>>
    {
        private readonly IMapper _mapper;
        private readonly IPostWriteRepository _postWriteRepository;
        private readonly IPostReadRepository _postReadRepository;
        public UpdatePostCommandHandler(
            IMapper mapper,
            IPostWriteRepository postWriteRepository,
            IPostReadRepository postReadRepository
            )
        {
            _mapper = mapper;
            _postWriteRepository = postWriteRepository;
            _postReadRepository = postReadRepository;
        }

        public async Task<BaseCommandResponse<GetPostOutput>> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<GetPostOutput>();
            var validator = new UpdatePostCommandHandlerValidatior();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                response.Data = null;
                response.Success = false;
                response.Message = null;
                response.Errors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var post = await _postReadRepository.GetAsync(x => x.Id == request.Id);
                post.Id = request.Id;
                post.UserId = request.UserId;
                post.LanguageId = request.LanguageId;
                post.CategoryId = request.CategoryId;
                post.Title = request.Title;
                post.Content = request.Content;
                post.Slug = request.Slug;
                post.Image = request.Image ?? post.Image;
                post.ImageAlt = request.ImageAlt;
                post.MetaKeywords = request.MetaKeywords;
                post.MetaDescription = request.MetaDescription;
                post.IsPublished = request.IsPublished;
                post.UpdatedById = request.UserId;
                post.UpdationDate = DateTime.UtcNow;
                var result = await _postWriteRepository.UpdateAsync(post);

                var resultMapp = _mapper.Map<GetPostOutput>(result);
                response.Id = resultMapp.Id;
                response.Data = resultMapp;
                response.Success = true;
                response.Message = PostMessages.UpdatedSuccess;
                response.Errors = null;
            }
            return response;
        }
    }
}