using HospitalSystem.Data.Enum;

namespace Hospital.Data.Models
{
    public class Patients
    {
        public int id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Address { get; set; }
        public BloodType BloodType { get; set; }
        public DateOnly CreatedDate { get; set; }
        public ICollection<Appointments>? Appointments { get; set; }
        public ICollection<MedicalRecords>? MedicalRecords { get; set; }
        public ICollection<PatientDoctor>? PatientDoctors { get; set; }
    }
}