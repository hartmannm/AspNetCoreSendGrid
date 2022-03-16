using ANCSG.Domain.Contexts.DoctorContext.Events;
using System.Threading.Tasks;

namespace ANCSG.Application.Contexts.DoctorContext.Events
{
    public interface IDoctorRegisteredIntegrationEvent
    {
        Task Execute(DoctorRegisteredEvent @event);
    }
}
