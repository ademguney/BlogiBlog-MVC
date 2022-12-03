namespace Blogi.Application.Features.Abouts.Commands.Delete
{
    public class DeleteAboutCommand : IRequest<BaseCommandResponse<int>>
    {
        public int Id { get; set; }
    }
}