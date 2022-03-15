using ANCSG.Application.Contexts.DoctorContext.DTOs;
using ANCSG.Application.Data;
using ANCSG.Application.Map;
using ANCSG.Application.Notification;
using ANCSG.Application.UseCase;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ANCSG.Application.Contexts.DoctorContext.UseCases
{
    public class GetAllDoctorsUseCase : UseCaseBase, IGetAllDoctorsUseCase
    {
        public GetAllDoctorsUseCase(INotifier notifier, IDataManager dataManager, IMap map) : base(notifier, dataManager, map)
        {
        }

        public async Task<IEnumerable<DoctorDTO>> Execute()
        {
            var repository = dataManager.DoctorRepository;
            var doctors = await repository.GetAllAsync();

            return doctors.Select(x => (DoctorDTO)x);
        }
    }
}
