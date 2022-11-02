using Blogi.Application.Features.MailSettings.Dtos.Get;

namespace Blogi.Application.Features.MailSettings.Commands.Update
{
    public class UpdateMailSettingCommand : IRequest<BaseCommandResponse<GetMailSettingOutput>>
    {
        public int Id { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool SslEnabled { get; set; }
        public bool UseDefaultCredentials { get; set; }
    }
}