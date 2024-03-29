﻿using Blogi.Application.Features.StringResources.Dtos.GetList;

namespace Blogi.Application.Features.StringResources.Queries.GetList
{
    public class GetListStringResourceQueryHandler : IRequestHandler<GetListStringResourceQuery, BaseCommandResponse<List<GetListStringResourceOutput>>>
    {
        private readonly IMapper _mapper;
        private readonly IStringResourceService _stringResourceService;

        public GetListStringResourceQueryHandler(IMapper mapper, IStringResourceService stringResourceService)
        {
            _mapper = mapper;
            _stringResourceService = stringResourceService;
        }

        public async Task<BaseCommandResponse<List<GetListStringResourceOutput>>> Handle(GetListStringResourceQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<List<GetListStringResourceOutput>>();
            var result = await _stringResourceService.GetListAsync();

            if (!result.Any())
            {
                response.Success = false;
                response.Message = StringResourceMessages.GetListNotExists;
                response.Errors = null;
                response.Data = new List<GetListStringResourceOutput>();
            }
            else
            {
                var resultMapp = _mapper.Map<List<GetListStringResourceOutput>>(result);
                response.Data = resultMapp;
                response.Success = true;
                response.Message = StringResourceMessages.GetListExists;
                response.Errors = null;
            }

            return response;
        }
    }
}