﻿using ANCSG.Application.Contexts.DoctorContext.DTOs;
using ANCSG.Application.Contexts.DoctorContext.Factories;
using ANCSG.Application.Data;
using ANCSG.Application.UseCase;
using ANCSG.Domain.Notification;
using System.Threading.Tasks;

namespace ANCSG.Application.Contexts.DoctorContext.UseCases
{
    public class RegisterDoctorUseCase : UseCaseBase, IRegisterDoctorUseCase
    {
        public RegisterDoctorUseCase(INotifier notifier, IDataManager dataManager) : base(notifier, dataManager)
        {
        }

        public async Task<DoctorDTO> Execute(RegisterDoctorRequest request)
        {
            var doctor = DoctorFactory.Create(request);
            var repository = dataManager.DoctorRepository;

            await repository.CreateAsync(doctor);
            await repository.SaveChangesAsync();

            return (DoctorDTO)doctor;
        }
    }
}
