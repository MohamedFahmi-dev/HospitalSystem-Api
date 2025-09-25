using Hospital.core.Features.MedicalRecord.Query.Response;

namespace Hospital.core.Mapping.MedicalRecord
{
    public partial class MedicalRecordProfile
    {
        public void GetRecordsByPatientIdMapping()
        {
            CreateMap<MedicalRecords, GetMedicalRecordsByPatientResponse>();

        }
    }
}
