using AutoMapper;
using Hospital.core.Features.Doctor.Command.Models;

namespace Hospital.core.Mapping.Doctor
{
    public partial class DoctorProfile : Profile
    {
        public void UpdateCommandMapping()
        {
            CreateMap<UpdateDoctorCommand, Doctors>();
        }
    }
}
