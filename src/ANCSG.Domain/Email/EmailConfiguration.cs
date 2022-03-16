namespace ANCSG.Domain.Email
{
    public class EmailConfiguration
    {
        public EmailAddress From { get; init; }

        public EmailTemplates Templates { get; init; }
    }
}
