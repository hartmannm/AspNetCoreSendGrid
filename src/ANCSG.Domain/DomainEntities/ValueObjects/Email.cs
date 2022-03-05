namespace ANCSG.Domain.DomainEntities.ValueObjects
{
    public struct Email
    {
        public string Address { get; private set; }

        public Email(string address)
        {
            Address = address;
        }
    }
}
