using Blogi.Application.Features.Categories.Dtos.Get;

namespace Blogi.Application.Features.Categories.Commands.Create
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, BaseCommandResponse<GetCategoryOutput>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly ICategoryWriteRepository _categoryWriteRepository;

        public CreateCategoryCommandHandler(
            IMapper mapper,
            ICategoryReadRepository categoryReadRepository,
            ICategoryWriteRepository categoryWriteRepository
            )
        {
            _mapper = mapper;
            _categoryReadRepository = categoryReadRepository;
            _categoryWriteRepository = categoryWriteRepository;
        }

        public async Task<BaseCommandResponse<GetCategoryOutput>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<GetCategoryOutput>();
            var validator = new CreateCategoryCommandHandlerValidatior(_categoryReadRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "";
                response.Errors = validatorResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                request.Slug = request.Slug.FriendlyUrl();
                var categoryMapp = _mapper.Map<Category>(request);
                var result = await _categoryWriteRepository.AddAsync(categoryMapp);
                var resultMapp = _mapper.Map<GetCategoryOutput>(result);

                response.Id = resultMapp.Id;
                response.Data = resultMapp;
                response.Success = true;
                response.Message = CategoryMessages.CreatedSuccess;
                response.Errors = null;
            }
            return response;
        }
    }
}