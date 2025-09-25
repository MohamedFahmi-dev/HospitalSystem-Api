using FluentValidation;
using Hospital.core.Features.Patient.Command.Models;

namespace Hospital.core.Features.Patient.Command.Validation
{
    public class DeletePatientValidation : AbstractValidator<DeletePatientCommand>
    {
        public DeletePatientValidation()
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
