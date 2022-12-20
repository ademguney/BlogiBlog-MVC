namespace Blogi.Application.Features.MailSends.Commands.ContactMailSend
{
    public class ContactMailSendCommandHandler : IRequestHandler<ContactMailSendCommand, BaseCommandResponse<bool>>
    {
        private readonly IMailFactoryService _mailFactoryService;

        public ContactMailSendCommandHandler(IMailFactoryService mailFactoryService)
        {
            _mailFactoryService = mailFactoryService;
        }

        public async Task<BaseCommandResponse<bool>> Handle(ContactMailSendCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<bool>();
            var validator = new ContactMailSendCommandHandlerValidatior();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                response.Data = false;
                response.Success = false;
                response.Message = null;
                response.Errors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList();

            }
            else
            {
                var result = _mailFactoryService.SendContactdMail(request.Email, request.Name, request.Surname, request.Subject, request.Body);

                response.Data = true;
                response.Success = true;
                response.Message = MailSettingMessages.MailSendSuccessfully;
                response.Errors = null;
            }
            return response;
        }
    }
}
