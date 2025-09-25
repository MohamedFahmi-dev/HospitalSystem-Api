using AutoMapper;

namespace Hospital.Services.Mapping
{
    public class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {
            CreateMap<Appointments, Appointments>();
        }
    }
}
