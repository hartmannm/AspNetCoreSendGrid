using ANCSG.Domain.Contexts.DoctorContext.Entities;
using System;

namespace ANCSG.Application.Contexts.DoctorContext.DTOs
{
    public class DoctorDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string CRM { get; set; }

        public static explicit operator DoctorDTO(Doctor doctor)
        {
            return new DoctorDTO
            {
                Id = doctor.Id,
                Name = doctor.Name,
                Email = doctor.Email,
                CRM = $"{doctor.CRMNumber}/{doctor.CRMUF}"
            };
        }
    }
}
