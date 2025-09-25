using Hospital.core.Base;
using MediatR;

namespace Hospital.core.Features.Appointment.Query.Model
{
    public class IsDoctorAvailableQuery : IRequest<Response<bool>>
    {
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }

        public IsDoctorAvailableQuery(int doctorId, DateTime appointmentDate)
        {
            DoctorId = doctorId;
            AppointmentDate = appointmentDate;
        }
    }
}
