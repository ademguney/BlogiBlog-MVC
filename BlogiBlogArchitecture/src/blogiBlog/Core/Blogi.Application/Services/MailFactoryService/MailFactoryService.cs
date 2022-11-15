using Core.Application.Security.Hashing;
using Core.Infrastructure.MailKit;
using Microsoft.EntityFrameworkCore;

namespace Blogi.Application.Services.MailFactoryService
{
    public class MailFactoryService : IMailFactoryService
    {
        private readonly IMailService _mailService;
        private readonly IMailSettingReadRepository _mailConfig;

        public MailFactoryService(IMailService mailService, IMailSettingReadRepository mailConfig)
        {
            _mailService = mailService;
            _mailConfig = mailConfig;
        }

        public async Task SendForgotPasswordMail(string toEmail, string newPassword)
        {
            var mailSettings = await _mailConfig.GetAll().FirstOrDefaultAsync();
            var deccPassword = EnDecode.Decrypt(mailSettings.Password, StaticParams.PasswordParams);
            var config = new MailConfig
            {
                FullName = mailSettings.FullName,
                Email = mailSettings.Email,
                Password = deccPassword,
                Host = mailSettings.Host,
                Port = mailSettings.Port

            };
            var mail = new Mail
            {
                Subject = "BLOGI BLOG, Forget Password",
                ToEmail = toEmail,
                Attachments = null,
                Body = "Have a nice day, " +
               "<br> This Email has been sent to you via BLOGI BLOG FORGET PASSWORD SERVICE" +
               "<br>" + "User password: <b>" + newPassword + "</b>" +
               "<br>" + "<i>If you encounter any technical problems, you can looking the Github Repository.</i>" +
               "<br>" + "<i>We wish you good work.</i>"
            };

            await _mailService.SendMail(mail, config);
        }
    }
}
