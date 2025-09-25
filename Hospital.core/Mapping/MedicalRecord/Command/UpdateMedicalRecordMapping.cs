using Hospital.core.Features.MedicalRecord.Command.Model;

namespace Hospital.core.Mapping.MedicalRecord
{
    public partial class MedicalRecordProfile
    {
        public void UpdateMedicalRecordMapping()
        {
            CreateMap<UpdateMedicalRecordCommand, MedicalRecords>();
        }
    }
}
