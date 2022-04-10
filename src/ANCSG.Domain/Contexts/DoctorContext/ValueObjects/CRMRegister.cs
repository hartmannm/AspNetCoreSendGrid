using ANCSG.Domain.DomainEntities.Enums;

namespace ANCSG.Domain.Contexts.DoctorContext.ValueObjects
{
    public record CRMRegister
    {
        public UF Uf { get; init; }

        public long Number { get; init; }

        public CRMRegister(UF uf, long number)
        {
            Uf = uf;
            Number = number;
        }

        public string Description() => $"{Number}/{Uf.ToString().ToUpper()}";
    }
}
