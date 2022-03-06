using ANCSG.Application.Contexts.DoctorContext.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ANCSG.Application.Contexts.DoctorContext.UseCases
{
    public interface IGetAllDoctorsUseCase
    {
        Task<IEnumerable<DoctorDTO>> Execute();
    }
}
