using ANCSG.Domain.Messages.Events;

namespace ANCSG.Domain.Contexts.DoctorContext.Events
{
    public sealed class DoctorRegisteredEvent : IntegrationEvent
    {
        public string FirstName { get; init; }

        public string LastName { get; init; }

        public string Email { get; init; }

        public DoctorRegisteredEvent(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
