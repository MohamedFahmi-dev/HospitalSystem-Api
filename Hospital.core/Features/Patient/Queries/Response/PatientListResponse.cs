namespace Hospital.core.Features.Patient.Queries.Response
{
    public class PatientListResponse
    {

        public int id { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public string? PhoneNumber { get; set; }
        public required string Email { get; set; }
        public string? AppointmentDate { get; set; }
    }
}
