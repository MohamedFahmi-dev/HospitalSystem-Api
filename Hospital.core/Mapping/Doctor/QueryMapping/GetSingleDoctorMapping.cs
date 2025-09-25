using AutoMapper;
using Hospital.core.Features.Doctor.Query.Response;

namespace Hospital.core.Mapping.Doctor
{
    public partial class DoctorProfile : Profile
    {
        public void GetSingleDoctorMapping()
        {
            CreateMap<global::Doctors, GetSingleDoctorResponse>();
        }
    }
}
