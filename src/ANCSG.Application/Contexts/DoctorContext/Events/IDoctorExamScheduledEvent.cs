using ANCSG.Domain.Contexts.MedicalExamContext.Events;
using System.Threading.Tasks;

namespace ANCSG.Application.Contexts.DoctorContext.Events
{
    public interface IDoctorExamScheduledEvent
    {
        Task Execute(ExamScheduledEvent @event);
    }
}
