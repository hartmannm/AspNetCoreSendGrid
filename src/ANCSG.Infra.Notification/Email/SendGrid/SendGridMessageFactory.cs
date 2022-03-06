using SendGrid.Helpers.Mail;

namespace ANCSG.Infra.Notification.Email.SendGrid
{
    public sealed class SendGridMessageFactory
    {
        public SendGridMessage Create(Domain.Email.Email email)
        {
            var message = new SendGridMessage();
            message.SetFrom(email.From.Address, email.From.Name);
            message.AddTos(AdaptAdresses(email.EmailAdresses));
            message.SetTemplateId(email.TemplateId);
            message.SetTemplateData(email.TemplateData);

            if (email.CCs is not null)
                message.AddCcs(AdaptAdresses(email.CCs));

            if (email.BCCs is not null)
                message.AddBccs(AdaptAdresses(email.BCCs));

            SetSendAt(message, email.SendAt);
            SetReplyTo(message, email.ReplyTo);
            return message;
        }

        private void SetSendAt(SendGridMessage message, DateTime? sendAt)
        {
            if (sendAt.HasValue)
                message.SetSendAt(sendAt.Value.Ticks);
        }

        private void SetReplyTo(SendGridMessage message, Domain.Email.EmailAddress replyTo)
        {
            if (replyTo is not null)
                message.SetReplyTo(new EmailAddresAdapter(replyTo));
        }

        private List<EmailAddress> AdaptAdresses(IEnumerable<Domain.Email.EmailAddress> addresses)
        {
            var adresssesList = new List<EmailAddress>();

            foreach (var address in addresses)
                adresssesList.Add(new EmailAddresAdapter(address));

            return adresssesList;
        }
    }
}
