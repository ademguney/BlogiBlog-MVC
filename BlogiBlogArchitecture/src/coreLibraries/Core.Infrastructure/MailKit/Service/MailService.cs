using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace Core.Infrastructure.MailKit.Service
{
    public class MailService : IMailService
    {
        public async Task SendMail(Mail input, MailConfig config)
        {
            try
            {
                var email = new MimeMessage();

                email.Sender = MailboxAddress.Parse(config.Email);
                email.From.Add(new MailboxAddress("BLOGI BLOG", config.Email));
                email.To.Add(MailboxAddress.Parse(input.ToEmail));
                email.Subject = input.Subject;

                var builder = new BodyBuilder();
                if (input.Attachments != null)
                {
                    byte[] fileBytes;
                    foreach (var file in input.Attachments)
                    {
                        if (file.Length > 0)
                        {
                            using (var ms = new MemoryStream())
                            {
                                file.CopyTo(ms);
                                fileBytes = ms.ToArray();
                            }
                            builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                        }
                    }
                }

                builder.HtmlBody = input.Body;
                email.Body = builder.ToMessageBody();

                using var client = new SmtpClient();
                // Accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                await client.ConnectAsync(config.Host, config.Port, SecureSocketOptions.StartTls);

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                // Note: only needed if the SMTP server requires authentication
                await client.AuthenticateAsync(config.Email, config.Password);

                await client.SendAsync(email);
                await client.DisconnectAsync(true);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}