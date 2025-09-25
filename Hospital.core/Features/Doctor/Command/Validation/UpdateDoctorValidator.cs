using FluentValidation;
using Hospital.core.Features.Doctor.Command.Models;

namespace Hospital.core.Features.Doctor.Command.Validation
{
    public class UpdateDoctorValidator : AbstractValidator<UpdateDoctorCommand>
    {
        public UpdateDoctorValidator()
        {
            ApplyValidationRules();

        }
        public void ApplyValidationRules()
        {
            RuleFor(x => x.Id).NotEmpty()
            .WithMessage(" ID is required")
            .NotNull().WithMessage("Id cant be Null");

            RuleFor(x => x.FirstName)
              .NotEmpty()
              .WithMessage("First name is required")
              .NotNull()
              .WithMessage("First name cannot be null")
              .Length(2, 50)
              .WithMessage("First name must be between 2 and 50 characters")
              .Matches(@"^[a-zA-Z\s\-']+$")
              .WithMessage("First name can only contain letters, spaces, hyphens, and apostrophes");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last name is required")
                .NotNull()
                .WithMessage("Last name cannot be null")
                .Length(2, 50)
                .WithMessage("Last name must be between 2 and 50 characters")
                .Matches(@"^[a-zA-Z\s\-']+$")
                .WithMessage("Last name can only contain letters, spaces, hyphens, and apostrophes");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Please enter a valid email address")
                .MaximumLength(100)
                .WithMessage("Email cannot exceed 100 characters");


            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("Phone number is required")
                .Matches(@"^[\+]?[1-9][\d]{10,14}$")
                .WithMessage("Please enter a valid phone number")
                .WithMessage("Phone number already exists in the system");

            RuleFor(x => x.YearOfExperience)
                .NotNull()
                .WithMessage("Years of experience is required")
                .GreaterThanOrEqualTo(0)
                .WithMessage("Years of experience cannot be negative")
                .LessThanOrEqualTo(60)
                .WithMessage("Years of experience cannot exceed 60 years");

        }


    }
}
