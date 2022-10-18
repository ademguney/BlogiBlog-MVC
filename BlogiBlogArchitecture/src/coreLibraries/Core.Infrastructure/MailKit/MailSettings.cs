namespace Core.Infrastructure.MailKit
{
    public class MailSettings
    {
        public MailSettings() { }
        
        public MailSettings(string host, int port, string senderFullName, string email, string password, bool sslEnabled, bool useDefaultCredentials)
        {
            Host = host;
            Port = port;
            SenderFullName = senderFullName;
            Email = email;
            Password = password;
            SslEnabled = sslEnabled;
            UseDefaultCredentials = useDefaultCredentials;
        }

        public string Host { get; set; }
        public int Port { get; set; }
        public string SenderFullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool SslEnabled { get; set; }
        public bool UseDefaultCredentials { get; set; }
    }
}
