using Hospital.core.Features.Doctor.Query.Response;

namespace Hospital.core.Mapping.Doctor
{
    public partial class DoctorProfile
    {
        public void GetDoctorListMapping()
        {
            CreateMap<Doctors, GetDoctorsListResponse>();

        }
    }
}
