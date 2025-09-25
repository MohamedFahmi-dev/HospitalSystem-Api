using HospitalSystem.Data.Enum;

namespace Hospital.core.Features.Appointment.Query.Response
{
    public class GetAppointmentsByPatientResponse
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public string PatientFullName => $"{PatientFirstName} {PatientLastName}";
        public int DoctorId { get; set; }
        public string DoctorsFirstName { get; set; }
        public string DoctorsLastName { get; set; }
        public string DoctorFullName => $"{DoctorsFirstName} {DoctorsLastName}";
        public DateTime AppointmentDate { get; set; }
        public Status Status { get; set; }
        public string? Reason { get; set; }
    }
}
