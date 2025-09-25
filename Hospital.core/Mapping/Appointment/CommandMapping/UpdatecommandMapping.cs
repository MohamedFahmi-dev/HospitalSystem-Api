using Hospital.core.Features.Appointment.Command.Model;

namespace Hospital.core.Mapping.Appointment
{
    public partial class AppointmentProfile
    {
        public void UpdatecommandMapping()
        {
            CreateMap<UpdateAppointmentCommand, Appointments>();

        }
    }
}
