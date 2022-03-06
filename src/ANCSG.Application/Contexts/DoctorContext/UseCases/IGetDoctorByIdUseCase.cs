using ANCSG.Application.Contexts.DoctorContext.DTOs;
using System;
using System.Threading.Tasks;

namespace ANCSG.Application.Contexts.DoctorContext.UseCases
{
    public interface IGetDoctorByIdUseCase
    {
        Task<DoctorDTO> Execute(Guid id);
    }
}
