namespace ANCSG.Domain.DomainEntities.ValueObjects
{
    public record Email
    {
        public string Address { get; init; }

        public Email(string address)
        {
            Address = address;
        }
    }
}
