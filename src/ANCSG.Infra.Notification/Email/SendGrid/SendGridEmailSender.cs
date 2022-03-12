using ANCSG.Application.EmailNotification;
using SendGrid;

namespace ANCSG.Infra.Notification.Email.SendGrid
{
    public class SendGridEmailSender : IEmailSender
    {
        private readonly ISendGridClient _sendGridClient;

        public SendGridEmailSender(ISendGridClient sendGridClient)
        {
            _sendGridClient = sendGridClient;
        }

        public async Task SendAsync(Domain.Email.Email email)
        {
            var messagFactory = new SendGridMessageFactory();
            var message = messagFactory.Create(email);

            await _sendGridClient.SendEmailAsync(message);
        }
    }
}
