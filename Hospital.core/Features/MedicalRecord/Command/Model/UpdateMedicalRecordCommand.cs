using Hospital.core.Base;
using MediatR;

namespace Hospital.core.Features.MedicalRecord.Command.Model
{
    public class UpdateMedicalRecordCommand : IRequest<Response<MedicalRecords>>
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public DateTime VisitDate { get; set; }
        public string Diagnosis { get; set; }
        public string Prescription { get; set; }
        public string Notes { get; set; }
    }
}
