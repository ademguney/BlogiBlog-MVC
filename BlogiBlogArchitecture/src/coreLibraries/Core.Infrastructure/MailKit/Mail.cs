using Microsoft.AspNetCore.Http;

namespace Core.Infrastructure.MailKit
{
    public class Mail
    {
        public Mail() { }

        public Mail(string toEmail, string subject, string body, List<IFormFile> attachments)
        {
            ToEmail = toEmail;
            Subject = subject;
            Body = body;
            Attachments = attachments;
        }

        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<IFormFile> Attachments { get; set; }
    }
}