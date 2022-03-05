namespace ANCSG.Domain.DomainEntities
{
    public abstract class Person : Entity
    {
        public string Name { get; private set; }

        public string Email { get; private set; }

        public string Contact { get; private set; }

        protected Person()
        {
        }

        public Person(string name, string email, string contact)
        {
            Name = name;
            Email = email;
            Contact = contact;
        }
    }
}
