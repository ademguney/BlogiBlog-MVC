using Blogi.Application.Features.Posts.Dtos.GetMostReadPost;

namespace Blogi.Application.Features.Posts.Queries.GetMostReadPost
{
	public class GetMostReadPostQuery : IRequest<BaseCommandResponse<List<GetMostReadPostOutput>>>
	{
	}
}