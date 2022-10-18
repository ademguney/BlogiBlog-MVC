using System.Net.Mail;

namespace Core.Infrastructure.MailKit
{
    public class Mail
    {
        public Mail() { }

        public Mail(string subject, string textBody, string htmlBody, string toFullName, string toEmail, AttachmentCollection? attachments)
        {
            Subject = subject;
            TextBody = textBody;
            HtmlBody = htmlBody;
            ToFullName = toFullName;
            ToEmail = toEmail;
            Attachments = attachments;
        }

        public string Subject { get; set; }
        public string TextBody { get; set; }
        public string HtmlBody { get; set; }
        public string ToFullName { get; set; }
        public string ToEmail { get; set; }
        public AttachmentCollection? Attachments { get; set; }
    }
}
