namespace ANCSG.Application.Contexts.DoctorContext.UseCases
{
    public sealed class RegisterDoctorRequest
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string CRMUF { get; set; }

        public long CRMNumber { get; set; }
    }
}
