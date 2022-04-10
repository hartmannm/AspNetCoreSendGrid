using ANCSG.Domain.Messages.Events;
using System;

namespace ANCSG.Domain.Contexts.MedicalExamContext.Events
{
    public sealed class ExamScheduledEvent : IntegrationEvent
    {
        public Guid ExamId { get; }

        public ExamScheduledEvent(Guid examId)
        {
            ExamId = examId;
        }
    }
}
