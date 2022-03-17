namespace ANCSG.Application.Contexts.DoctorContext.UseCases
{
    public sealed record RegisterDoctorRequest
    {
        public string FirstName { get; init; }

        public string LastName { get; init; }

        public string Email { get; init; }

        public string CRMUF { get; init; }

        public long CRMNumber { get; init; }
    }
}
