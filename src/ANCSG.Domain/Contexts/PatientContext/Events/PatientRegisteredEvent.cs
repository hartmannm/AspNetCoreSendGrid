using ANCSG.Domain.Messages.Events;

namespace ANCSG.Domain.Contexts.PatientContext.Events
{
    public class PatientRegisteredEvent : IntegrationEvent
    {
        public string FirstName { get; }

        public string LastName { get; }

        public string Email { get; }


        public PatientRegisteredEvent(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
