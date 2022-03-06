namespace ANCSG.Domain.Email
{
    public class EmailAddress
    {
        public string Address { get; private set; }

        public string Name { get; private set; }

        public EmailAddress(string address, string name)
        {
            Address = address;
            Name = name;
        }
    }
}
