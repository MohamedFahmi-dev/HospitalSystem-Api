using FluentValidation;
using Hospital.core.Features.Patient.Command.Models;

namespace Hospital.core.Features.Patient.Command.Validation
{
    public class EditPatientsvalidator : AbstractValidator<EditPatientsCommand>
    {
        public EditPatientsvalidator()
        {
            ApplyValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .NotNull().MaximumLength(100).WithMessage("First name cannot be longer than 100 characters.");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
               .NotNull().MaximumLength(100).WithMessage("Last name cannot be longer than 100 characters.");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .NotNull().EmailAddress().WithMessage("Invalid Email Address");
            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("Date of birth is required")
                .LessThan(DateOnly.FromDateTime(DateTime.Now)).WithMessage("Date of birth must be in the past");
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required")
                .MaximumLength(200).WithMessage("Address cannot exceed 200 characters");
            RuleFor(x => x.BloodType)
                .IsInEnum().WithMessage("Invalid blood type");


        }

    }

}

