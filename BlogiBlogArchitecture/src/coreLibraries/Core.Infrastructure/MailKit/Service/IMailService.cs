namespace Core.Infrastructure.MailKit.Service
{
    public interface IMailService
    {
        Task SendMail(Mail input, MailConfig config);
    }
}