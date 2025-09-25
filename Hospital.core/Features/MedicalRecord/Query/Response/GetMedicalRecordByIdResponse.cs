namespace Hospital.core.Features.MedicalRecord.Query.Response
{
    public class GetMedicalRecordByIdResponse
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public string PatientFullName => $"{PatientFirstName} {PatientLastName}";
        public string PatientEmail { get; set; }
        public string PatientPhone { get; set; }
        public DateTime VisitDate { get; set; }
        public string Diagnosis { get; set; }
        public string Prescription { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
