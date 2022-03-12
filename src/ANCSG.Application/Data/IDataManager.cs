using ANCSG.Application.Contexts.DoctorContext.Data;
using ANCSG.Application.Contexts.MedicalExamContext.Data;
using ANCSG.Application.Contexts.PatientContext.Data;

namespace ANCSG.Application.Data
{
    public interface IDataManager
    {
        IDoctorRepository DoctorRepository { get; }

        IPatientRepository PatientRepository { get; }
        
        IMedicalExamRepository MedicalExamRepository { get; }
    }
}
