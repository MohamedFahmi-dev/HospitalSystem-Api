using Hospital.core.Base;
using MediatR;

namespace Hospital.core.Features.MedicalRecord.Command.Model
{
    public class CreateMedicalRecordCommand : IRequest<Response<string>>
    {
        public int PatientId { get; set; }
        public DateTime VisitDate { get; set; }
        public string Diagnosis { get; set; }
        public string Prescription { get; set; }
        public string Notes { get; set; }
    }
}
