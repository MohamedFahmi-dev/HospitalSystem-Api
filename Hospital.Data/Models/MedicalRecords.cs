using Hospital.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

public class MedicalRecords
{
    public int Id { get; set; }

    public int PatientId { get; set; }
    [ForeignKey("PatientId")]
    public Patients Patient { get; set; }

    public DateTime VisitDate { get; set; }

    public string Diagnosis { get; set; }

    public string Prescription { get; set; }

    public string Notes { get; set; }
}