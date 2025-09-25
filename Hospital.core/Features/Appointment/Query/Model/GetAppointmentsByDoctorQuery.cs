using Hospital.core.Base;
using Hospital.core.Features.Appointment.Query.Response;
using MediatR;

namespace Hospital.core.Features.Appointment.Query.Model
{
    public class GetAppointmentsByDoctorQuery : IRequest<Response<List<GetAppointmentsByDoctorResponse>>>
    {
        public int DoctorId { get; set; }
        public GetAppointmentsByDoctorQuery(int doctorId)
        {
            DoctorId = doctorId;
        }

    }
}
