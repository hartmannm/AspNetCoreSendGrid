using SendGrid.Helpers.Mail;

namespace ANCSG.Infra.Notification.Email.SendGrid
{
    public sealed class EmailAddresAdapter : EmailAddress
    {
        public EmailAddresAdapter(Domain.Email.EmailAddress address) : base(address.Address, address.Name)
        {
        }
    }
}
