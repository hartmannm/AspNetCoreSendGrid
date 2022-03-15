namespace ANCSG.Application.Contexts.DoctorContext.UseCases
{
    public sealed class RegisterDoctorRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string CRMUF { get; set; }

        public long CRMNumber { get; set; }
    }
}
