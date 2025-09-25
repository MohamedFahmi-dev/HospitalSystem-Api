using Hospital.core.Base;
using HospitalSystem.Data.Enum;
using MediatR;

namespace Hospital.core.Features.Appointment.Command.Model
{
    public class UpdateAppointmentCommand : IRequest<Response<Appointments>>
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public Status Status { get; set; }
        public string? Reason { get; set; }
    }
}
