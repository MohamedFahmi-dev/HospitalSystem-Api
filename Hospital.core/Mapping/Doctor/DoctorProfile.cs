using AutoMapper;

namespace Hospital.core.Mapping.Doctor
{
    public partial class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            GetDoctorListMapping();
            GetSingleDoctorMapping();
            CreateCommandMapping();
            UpdateCommandMapping();
        }
    }


}
