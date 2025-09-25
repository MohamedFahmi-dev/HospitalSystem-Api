using AutoMapper;

namespace Hospital.core.Mapping.MedicalRecord
{
    public partial class MedicalRecordProfile : Profile
    {
        public MedicalRecordProfile()
        {
            GetAllMedicalRecordMapping();
            GetMedicalRecordByIdMapping();
            GetRecordsByPatientIdMapping();
            CreateMedicalRecordMapping();
            UpdateMedicalRecordMapping();
            DeleteMedicalRecordMapping();

        }

    }
}
