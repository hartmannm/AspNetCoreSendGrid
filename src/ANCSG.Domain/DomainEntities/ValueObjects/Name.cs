namespace ANCSG.Domain.DomainEntities.ValueObjects
{
    public record Name
    {
        public string FirstName { get; init; }

        public string LastName { get; init; }

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
