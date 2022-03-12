using ANCSG.Application.Contexts.DoctorContext.Data;
using ANCSG.Application.Contexts.MedicalExamContext.Data;
using ANCSG.Application.Contexts.PatientContext.Data;
using ANCSG.Application.Data;

namespace ANCSG.Infra.Data.Repositories
{
    public class DataManager : IDataManager
    {
        private readonly IPatientRepository _patientRepository;

        private readonly IDoctorRepository _doctorRepository;

        private readonly IMedicalExamRepository _medicalExamRepository;

        public IDoctorRepository DoctorRepository => _doctorRepository;

        public IPatientRepository PatientRepository => _patientRepository;

        public IMedicalExamRepository MedicalExamRepository => _medicalExamRepository;

        public DataManager(IPatientRepository patientRepository, IDoctorRepository doctorRepository, IMedicalExamRepository medicalExamRepository)
        {
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
            _medicalExamRepository = medicalExamRepository;
        }
    }
}
