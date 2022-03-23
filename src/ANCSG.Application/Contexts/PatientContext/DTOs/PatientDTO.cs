using System;

namespace ANCSG.Application.Contexts.PatientContext.DTOs
{
    public record PatientDTO
    {
        public Guid Id { get; init; }

        public string Name { get; init; }

        public string Email { get; init; }

        public DateTime BirthDate { get; init; }
    }
}
