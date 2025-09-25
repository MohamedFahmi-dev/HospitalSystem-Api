using Hospital.core.Features.Appointment.Query.Response;

namespace Hospital.core.Mapping.Appointment
{
    public partial class AppointmentProfile
    {
        public void GetAllAppointmentsMapping()
        {
            CreateMap<Appointments, GetAllAppointmentsResponse>();
        }
    }
}
