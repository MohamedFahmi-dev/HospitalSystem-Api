using Hospital.core.Base;
using HospitalSystem.Data.Enum;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Hospital.core.Features.Patient.Command.Models
{
    public class CreatePatientsCommand : IRequest<Response<string>>
    {

        [Required]
        [StringLength(100, ErrorMessage = "First name cannot be longer than 100 characters.")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Last name cannot be longer than 100 characters.")]
        public string LastName { get; set; }

        public string? PhoneNumber { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        public DateOnly DateOfBirth { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Blood type is required")]
        public BloodType BloodType { get; set; }


    }
}
