using AutoMapper;
using Hospital.core.Features.Auth.Command.Model;
using HospitalSystem.Models;

namespace Hospital.core.Mapping.Auth
{
    public class RegisterMapping : Profile
    {
        public RegisterMapping()
        {
            CreateMap<RegisterCommand, AppUser>();

        }
    }
}
