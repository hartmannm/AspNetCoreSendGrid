using ANCSG.Domain.DomainEntities.ValueObjects;

namespace ANCSG.Domain.DomainEntities
{
    public abstract class Person : Entity
    {
        public Name Name { get; private set; }

        public ValueObjects.Email Email { get; private set; }

        protected Person()
        {
        }

        public Person(string firstName, string lastName, string email)
        {
            Name = new Name(firstName: firstName, lastName: lastName);
            Email = new ValueObjects.Email(email);
        }
    }
}
