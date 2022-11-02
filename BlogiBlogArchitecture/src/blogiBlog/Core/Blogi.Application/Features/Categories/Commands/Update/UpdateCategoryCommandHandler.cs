using Blogi.Application.Features.Categories.Dtos.Get;

namespace Blogi.Application.Features.Categories.Commands.Update
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, BaseCommandResponse<GetCategoryOutput>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly ICategoryWriteRepository _categoryWriteRepository;

        public UpdateCategoryCommandHandler(
            IMapper mapper,
            ICategoryReadRepository categoryReadRepository,
            ICategoryWriteRepository categoryWriteRepository
            )
        {
            _mapper = mapper;
            _categoryReadRepository = categoryReadRepository;
            _categoryWriteRepository = categoryWriteRepository;
        }

        public async Task<BaseCommandResponse<GetCategoryOutput>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<GetCategoryOutput>();
            var validator = new UpdateCategoryCommandHandlerValidatior(_categoryReadRepository);
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

                var categoryMapp = _mapper.Map<Category>(request);
                var result = await _categoryWriteRepository.UpdateAsync(categoryMapp);
                var resultMapp = _mapper.Map<GetCategoryOutput>(result);

                response.Id = resultMapp.Id;
                response.Data = resultMapp;
                response.Success = true;
                response.Message = CategoryMessages.UpdatedSuccess;
                response.Errors = null;
            }
            return response;
        }
    }
}