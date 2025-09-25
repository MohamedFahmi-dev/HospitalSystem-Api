using AutoMapper;

namespace Hospital.Services.Mapping
{
    public class MedicalRecordProfile : Profile
    {
        public MedicalRecordProfile()
        {
            CreateMap<MedicalRecords, MedicalRecords>();
        }
    }
}
