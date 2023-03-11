using Blogi.Application.Features.Categories.Dtos.Get;

namespace Blogi.Application.Features.Categories.Queries.Get
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, BaseCommandResponse<GetCategoryOutput>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly ICategoryReadRepository _categoryReadRepository;

        public GetCategoryQueryHandler(
            IMapper mapper,
            ICategoryReadRepository categoryReadRepository,
            ICategoryService categoryService
            )
        {
            _mapper = mapper;
            _categoryService = categoryService;
            _categoryReadRepository = categoryReadRepository;
        }

        public async Task<BaseCommandResponse<GetCategoryOutput>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<GetCategoryOutput>();
            var validator = new GetCategoryQueryHandlerValidatior(_categoryReadRepository);
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
                var result = await _categoryService.GetAsync(request.Id);
                var resultMapp = _mapper.Map<GetCategoryOutput>(result);

                response.Id = resultMapp.Id;
                response.Data = resultMapp;
                response.Success = true;
                response.Message = CategoryMessages.GetByIdExists;
                response.Errors = null;
            }
            return response;
        }
    }
}