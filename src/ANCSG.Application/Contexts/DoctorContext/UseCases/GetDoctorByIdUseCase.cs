using ANCSG.Application.Contexts.DoctorContext.DTOs;
using ANCSG.Application.Data;
using ANCSG.Application.Notification;
using ANCSG.Application.UseCase;
using System;
using System.Threading.Tasks;

namespace ANCSG.Application.Contexts.DoctorContext.UseCases
{
    public class GetDoctorByIdUseCase : UseCaseBase, IGetDoctorByIdUseCase
    {
        public GetDoctorByIdUseCase(INotifier notifier, IDataManager dataManager) : base(notifier, dataManager)
        {
        }

        public async Task<DoctorDTO> Execute(Guid id)
        {
            var repository = dataManager.DoctorRepository;
            var doctor = await repository.GetByIdAsync(id);

            return (DoctorDTO)doctor;
        }
    }
}
