namespace Blogi.Application.Services.MailFactoryService
{
    public interface IMailFactoryService
    {
        Task SendForgotPasswordMail(string toEmail, string newPassword);
        Task SendContactdMail(string email, string name, string surName, string subject, string body);
    }
}