using Hospital.core.Base;
using HospitalSystem.Data.Enum;
using MediatR;

namespace Hospital.core.Features.Doctor.Command.Models
{
    public class UpdateDoctorCommand : IRequest<Response<Doctors>>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public Specialization Specialization { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public int YearOfExperience { get; set; }
    }
}
