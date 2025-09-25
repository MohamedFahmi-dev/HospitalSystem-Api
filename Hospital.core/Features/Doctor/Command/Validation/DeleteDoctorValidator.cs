using FluentValidation;
using Hospital.core.Features.Doctor.Command.Models;

namespace Hospital.core.Features.Doctor.Command.Validation
{
    public class DeleteDoctorValidator : AbstractValidator<DeleteDoctorCommand>
    {
        public DeleteDoctorValidator()
        {
            ApplyValidationRules();
        }
        public void ApplyValidationRules()
        {
            RuleFor(x => x.Id)
          .NotEmpty()
          .WithMessage("Patient ID is required")
          .GreaterThan(0)
          .WithMessage("Patient ID must be greater than 0");

        }
    }
}
