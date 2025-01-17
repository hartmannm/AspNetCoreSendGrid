﻿using ANCSG.Application.Contexts.DoctorContext.DTOs;
using System.Threading.Tasks;

namespace ANCSG.Application.Contexts.DoctorContext.UseCases
{
    public interface IRegisterDoctorUseCase
    {
        Task<DoctorDTO> Execute(RegisterDoctorRequest request);
    }
}
