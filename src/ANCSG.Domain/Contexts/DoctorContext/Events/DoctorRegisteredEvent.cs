using ANCSG.Domain.Messages.Events;

namespace ANCSG.Domain.Contexts.DoctorContext.Events
{
    public sealed class DoctorRegisteredEvent : IntegrationEvent
    {
        public string FirstName { get; }

        public string LastName { get; }

        public string Email { get; }

        public DoctorRegisteredEvent(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
