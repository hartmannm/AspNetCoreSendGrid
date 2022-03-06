using ANCSG.Application.Contexts.DoctorContext.UseCases;
using ANCSG.Domain.Contexts.DoctorContext.Entities;
using ANCSG.Domain.DomainEntities.Enums;
using ANCSG.Domain.Extensions;

namespace ANCSG.Application.Contexts.DoctorContext.Factories
{
    public class DoctorFactory
    {
        public static Doctor Create(RegisterDoctorRequest request)
        {
            var uf = request.CRMUF.toEnum<UF>();
            return new Doctor(request.Name, request.Email, request.Phone, uf, request.CRMNumber);
        }
    }
}
