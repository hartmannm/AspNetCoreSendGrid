using ANCSG.Application.Contexts.PatientContext.DTOs;
using System;
using System.Threading.Tasks;

namespace ANCSG.Application.Contexts.PatientContext.UseCases
{
    public interface IGetPatientByIdUseCase
    {
        Task<PatientDTO> Execute(Guid id);
    }
}
