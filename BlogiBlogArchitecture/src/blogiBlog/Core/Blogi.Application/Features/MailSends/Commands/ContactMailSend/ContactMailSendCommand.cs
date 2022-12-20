namespace Blogi.Application.Features.MailSends.Commands.ContactMailSend
{
    public class ContactMailSendCommand : IRequest<BaseCommandResponse<bool>>
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}