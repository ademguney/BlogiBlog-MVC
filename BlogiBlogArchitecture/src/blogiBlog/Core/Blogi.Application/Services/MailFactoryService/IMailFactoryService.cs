namespace Blogi.Application.Services.MailFactoryService
{
    public interface IMailFactoryService
    {
        Task SendForgotPasswordMail(string toEmail, string newPassword);
    }
}