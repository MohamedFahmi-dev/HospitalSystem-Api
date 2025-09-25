using HospitalSystem.Data.Enum;

namespace Hospital.core.Features.Doctor.Query.Response
{
    public class GetDoctorPaginatedListResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public Specialization Specialization { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int YearOfExperience { get; set; }
        public GetDoctorPaginatedListResponse(int Id, string FirstName, string LastName, Specialization Specialization, string PhoneNumber, string Email, int YearOfExperience)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Specialization = Specialization;
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;
            this.YearOfExperience = YearOfExperience;
        }
    }
}
