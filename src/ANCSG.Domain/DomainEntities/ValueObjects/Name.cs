namespace ANCSG.Domain.DomainEntities.ValueObjects
{
    public struct Name
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
