using Blogi.Application.Features.Categories.Dtos.Get;

namespace Blogi.Application.Features.Categories.Commands.Delete
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, BaseCommandResponse<GetCategoryOutput>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly ICategoryWriteRepository _categoryWriteRepository;

        public DeleteCategoryCommandHandler(
            IMapper mapper,
            ICategoryReadRepository categoryReadRepository,
            ICategoryWriteRepository categoryWriteRepository
            )
        {
            _mapper = mapper;
            _categoryReadRepository = categoryReadRepository;
            _categoryWriteRepository = categoryWriteRepository;
        }

        public async Task<BaseCommandResponse<GetCategoryOutput>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<GetCategoryOutput>();
            var validator = new DeleteCategoryCommandHandlerValidatior(_categoryReadRepository);
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
                var result = await _categoryWriteRepository.DeleteAsync(categoryMapp);

                response.Id = result.Id;
                response.Data = null;
                response.Success = true;
                response.Message = CategoryMessages.DeletedSuccess;
                response.Errors = null;
            }
            return response;
        }
    }
}
