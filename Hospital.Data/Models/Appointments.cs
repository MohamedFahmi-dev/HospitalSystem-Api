using Hospital.Data.Models;
using HospitalSystem.Data.Enum;
using System.ComponentModel.DataAnnotations.Schema;

public class Appointments
{
    public int Id { get; set; }

    public int PatientId { get; set; }
    [ForeignKey("PatientId")]
    public Patients Patient { get; set; }
    public int DoctorId { get; set; }
    [ForeignKey("DoctorId")]
    public Doctors Doctors { get; set; }
    public DateTime AppointmentDate { get; set; }
    public Status Status { get; set; }
    public string? Reason { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}