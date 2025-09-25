
using AutoMapper;

namespace Hospital.Services.Mapping
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<Doctors, Doctors>();
        }
    }
}
