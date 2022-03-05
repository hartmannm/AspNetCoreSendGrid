using ANCSG.Domain.DomainEntities.Enums;

namespace ANCSG.Domain.Contexts.DoctorContext.ValueObjects
{
    public struct CRMRegister
    {
        public UF UFRegister { get; private set; }

        public long Number { get; private set; }

        public CRMRegister(UF uFRegister, long number)
        {
            UFRegister = uFRegister;
            Number = number;
        }
    }
}
