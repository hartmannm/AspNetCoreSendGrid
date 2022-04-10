using ANCSG.Domain.Contexts.MedicalExamContext.Events;
using System.Threading.Tasks;

namespace ANCSG.Application.Contexts.PatientContext.Events
{
    public interface IPatientExamScheduledEvent
    {
        Task Execute(ExamScheduledEvent @event);
    }
}
