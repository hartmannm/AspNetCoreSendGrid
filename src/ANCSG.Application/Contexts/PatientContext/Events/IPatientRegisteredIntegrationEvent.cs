using ANCSG.Domain.Contexts.PatientContext.Events;
using System.Threading.Tasks;

namespace ANCSG.Application.Contexts.PatientContext.Events
{
    public interface IPatientRegisteredIntegrationEvent
    {
        Task Execute(PatientRegisteredEvent @event);
    }
}
