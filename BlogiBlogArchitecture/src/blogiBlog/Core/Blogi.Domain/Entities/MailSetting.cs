using Core.Persistence.Common;

namespace Blogi.Domain.Entities
{
    public class MailSetting : BaseDomainEntity
    {
        public MailSetting() { }

        public MailSetting(int id, string host, int port, string fullName, string email, string password, bool sslEnabled, bool useDefaultCredentials) : base(id)
        {
            Host = host;
            Port = port;
            FullName = fullName;
            Email = email;
            Password = password;
            SslEnabled = sslEnabled;
            UseDefaultCredentials = useDefaultCredentials;
        }

        public string Host { get; set; }
        public int Port { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool SslEnabled { get; set; }
        public bool UseDefaultCredentials { get; set; }

    }
}
