using AutoMapper;

namespace Hospital.core.Mapping.Appointment
{
    public partial class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {
            GetApByDoctorMapping();
            GetApByPatientMapping();
            GetTodayApMapping();
            GetAllAppointmentsMapping();
            UpdatecommandMapping();
        }
    }
}
