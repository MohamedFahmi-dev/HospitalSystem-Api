namespace Hospital.core.Features.Patient.Queries.Response
{
    public class GetPatientPaginatedListResponse
    {
        public int id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public GetPatientPaginatedListResponse(int id, string FirstName, string LastName, string PhoneNumber, string Email, DateTime AppointmentDate)
        {
            this.id = id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;
            this.AppointmentDate = AppointmentDate;

        }
    }
}
