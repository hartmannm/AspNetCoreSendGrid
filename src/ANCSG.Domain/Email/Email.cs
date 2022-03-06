using System;
using System.Collections.Generic;

namespace ANCSG.Domain.Email
{
    public sealed class Email
    {
        public EmailAddress From { get; private set; }

        public DateTime? SendAt { get; private set; }

        public EmailAddress ReplyTo { get; private set; }

        public ICollection<EmailAddress> EmailAdresses { get; private set; }

        public ICollection<EmailAddress> CCs { get; private set; }

        public ICollection<EmailAddress> BCCs { get; private set; }

        public string TemplateId { get; private set; }

        public ITemplateData TemplateData { get; private set; }

        private Email()
        {
            EmailAdresses = new List<EmailAddress>();
        }

        public Email(EmailAddress from, string templateId, ITemplateData templateData) : this()
        {
            From = from;
            TemplateId = templateId;
            TemplateData = templateData;
        }

        public Email(EmailAddress from, string templateId, ITemplateData templateData, ICollection<EmailAddress> emailAdresses) : this(from, templateId, templateData)
        {
            From = from;
            TemplateId = templateId;
            TemplateData = templateData;
            EmailAdresses = emailAdresses;
        }

        public void AddAddress(EmailAddress address) => EmailAdresses.Add(address);

        public void SetReplyTo(EmailAddress replyTo) => ReplyTo = replyTo;

        public void Schedule(DateTime sendAt) => SendAt = sendAt;

        public void AddCC(EmailAddress CC)
        {
            if (CCs is null)
                CCs = new List<EmailAddress>();

            CCs.Add(CC);
        }

        public void AddBCC(EmailAddress BCC)
        {
            if (BCCs is null)
                BCCs = new List<EmailAddress>();

            BCCs.Add(BCC);
        }
    }
}
