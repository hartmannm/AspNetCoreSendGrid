using ANCSG.Application.UseCase;
using ANCSG.Domain.DomainEntities.Enums;
using FluentValidation;

namespace ANCSG.Application.Contexts.DoctorContext.UseCases
{
    public sealed record RegisterDoctorRequest : RequestBase
    {
        public string FirstName { get; init; }

        public string LastName { get; init; }

        public string Email { get; init; }

        public string CRMUF { get; init; }

        public long CRMNumber { get; init; }

        public override bool IsValid
        {
            get
            {
                validationResult = new RegisterDoctorRequestValidator().Validate(this);
                return validationResult.IsValid;
            }
        }
    }

    internal class RegisterDoctorRequestValidator : AbstractValidator<RegisterDoctorRequest>
    {
        public RegisterDoctorRequestValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("Informe o nome do médico");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Informe o sobrenome do médico");

            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Informe o email do médico")
                .EmailAddress().WithMessage("Email inválido");

            RuleFor(x => x.CRMUF)
                .IsEnumName(typeof(UF), caseSensitive: false)
                .WithMessage("UF do CRM inválido");

            RuleFor(x => x.CRMNumber)
                .NotEmpty()
                .WithMessage("Informe o registro do CRM");
        }
    }
}
