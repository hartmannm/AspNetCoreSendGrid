using ANCSG.Domain.Messages.Events;

namespace ANCSG.Domain.Contexts.PatientContext.Events
{
    public class PatientRegisteredEvent : IntegrationEvent
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }


        public PatientRegisteredEvent(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
