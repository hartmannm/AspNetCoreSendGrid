using ANCSG.Domain.Contexts.DoctorContext.Data;
using ANCSG.Domain.Contexts.MedicalExamContext.Data;
using ANCSG.Domain.Contexts.PatientContext.Data;

namespace ANCSG.Domain.Data
{
    public interface IDataManager
    {
        IDoctorRepository DoctorRepository { get; }

        IPatientRepository PatientRepository { get; }
        
        IMedicalExamRepository MedicalExamRepository { get; }
    }
}
