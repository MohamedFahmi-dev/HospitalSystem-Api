using HospitalSystem.Data.Enum;

namespace Hospital.core.Features.Doctor.Query.Response
{
    public class GetDoctorsListResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public Specialization Specialization { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int YearOfExperience { get; set; }
    }
}
