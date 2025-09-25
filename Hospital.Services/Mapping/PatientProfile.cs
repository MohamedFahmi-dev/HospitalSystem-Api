using AutoMapper;
using Hospital.Data.Models;

namespace Hospital.Services.Mapping
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<Patients, Patients>();
        }

    }
}
