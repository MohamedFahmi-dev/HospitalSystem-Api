using Hospital.Data.Models;
using HospitalSystem.Data.Enum;

public class Doctors
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Specialization Specialization { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public int YearOfExperience { get; set; }
    public ICollection<Appointments>? Appointments { get; set; }
    public ICollection<PatientDoctor>? PatientDoctors { get; set; }
}