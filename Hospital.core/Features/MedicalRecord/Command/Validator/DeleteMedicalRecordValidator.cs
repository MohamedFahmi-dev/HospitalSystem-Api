using FluentValidation;
using Hospital.core.Features.MedicalRecord.Command.Model;

namespace Hospital.core.Features.MedicalRecord.Command.Validator
{
    public class DeleteMedicalRecordValidator : AbstractValidator<DeleteMedicalRecordCommand>
    {
        public DeleteMedicalRecordValidator()
        {
            ApplyValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Medical record ID is required")
                .GreaterThan(0).WithMessage("Invalid medical record ID");
        }
    }
}
