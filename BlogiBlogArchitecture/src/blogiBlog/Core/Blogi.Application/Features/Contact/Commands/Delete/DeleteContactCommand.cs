namespace Blogi.Application.Features.Contact.Commands.Delete
{
    public class DeleteContactCommand : IRequest<BaseCommandResponse<int>>
    {
        public int Id { get; set; }
    }
}