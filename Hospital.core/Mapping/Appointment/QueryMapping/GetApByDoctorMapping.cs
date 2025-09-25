using Hospital.core.Features.Appointment.Query.Response;

namespace Hospital.core.Mapping.Appointment
{
    public partial class AppointmentProfile
    {

        public void GetApByDoctorMapping()
        {
            CreateMap<Appointments, GetAppointmentsByDoctorResponse>();
        }
    }
}
