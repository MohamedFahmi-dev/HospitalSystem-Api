using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Data.Models
{
    public class PatientDoctor
    {
        public int DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctors Doctor { get; set; }

        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patients Patient { get; set; }

        public DateTime FirstVisit { get; set; }

        public DateTime? LastVisit { get; set; }

        public bool IsActive { get; set; } = true;

        public string? Notes { get; set; }
    }
}