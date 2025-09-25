namespace Hospital.core.Features.MedicalRecord.Query.Response
{
    public class GetMedicalRecordsByPatientResponse
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public string PatientFullName => $"{PatientFirstName} {PatientLastName}";
        public DateTime VisitDate { get; set; }
        public string Diagnosis { get; set; }
        public string Prescription { get; set; }
        public string Notes { get; set; }
        public int DaysSinceVisit => (DateTime.Now - VisitDate).Days;
    }
}
