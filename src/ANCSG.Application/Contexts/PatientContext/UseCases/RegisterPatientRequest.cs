using ANCSG.Application.UseCase;
using FluentValidation;
using System;

namespace ANCSG.Application.Contexts.PatientContext.UseCases
{
    public sealed record RegisterPatientRequest : RequestBase
    {
        public string FirstName { get; init; }

        public string LastName { get; init; }

        public string Email { get; init; }

        public DateTime BirthDate { get; init; }

        public override bool IsValid
        {
            get
            {
                validationResult = new RegisterPatientRequestValidator().Validate(this);
                return validationResult.IsValid;
            }
        }
    }

    internal class RegisterPatientRequestValidator : AbstractValidator<RegisterPatientRequest>
    {
        public RegisterPatientRequestValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("Informe o nome do paciente");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Informe o sobrenome do mpacienteédico");

            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Informe o email do paciente")
                .EmailAddress().WithMessage("Email inválido");

            RuleFor(x => x.BirthDate)
                .LessThan(DateTime.UtcNow)
                .WithMessage("A data de nascimento deve ser menor que a data atual");
        }
    }
}
