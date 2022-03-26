using ANCSG.Application.UseCase;
using FluentValidation;
using System;

namespace ANCSG.Application.Contexts.MedicalExamContext.UseCases
{
    public sealed record ScheduleMedicalExamRequest : RequestBase
    {
        public Guid DoctorId { get; init; }

        public Guid PatientId { get; init; }

        public DateTime DateScheduled { get; init; }

        public override bool IsValid
        {
            get
            {
                validationResult = new ScheduleMedicalExamRequestValidator().Validate(this);
                return validationResult.IsValid;
            }
        }
    }

    internal class ScheduleMedicalExamRequestValidator : AbstractValidator<ScheduleMedicalExamRequest>
    {
        public ScheduleMedicalExamRequestValidator()
        {
            RuleFor(x => x.DoctorId)
                .NotEmpty()
                .WithMessage("Informe o médico");

            RuleFor(x => x.PatientId)
                .NotEmpty()
                .WithMessage("Informe o paciente");

            RuleFor(x => x.DateScheduled)
                .GreaterThanOrEqualTo(x => DateTime.Now)
                .WithMessage("A data da consulta deve ser igual ou superior a data atual");
        }
    }
}
