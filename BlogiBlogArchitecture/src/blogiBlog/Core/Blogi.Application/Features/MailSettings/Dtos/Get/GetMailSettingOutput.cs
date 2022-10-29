namespace Blogi.Application.Features.MailSettings.Dtos.Get
{
    public class GetMailSettingOutput
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
