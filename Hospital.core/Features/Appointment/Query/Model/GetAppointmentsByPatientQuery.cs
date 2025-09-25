using Hospital.core.Base;
using Hospital.core.Features.Appointment.Query.Response;
using MediatR;

namespace Hospital.core.Features.Appointment.Query.Model
{
    public class GetAppointmentsByPatientQuery : IRequest<Response<List<GetAppointmentsByPatientResponse>>>
    {
        public int PatientId { get; set; }
        public GetAppointmentsByPatientQuery(int patientId)
        {
            PatientId = patientId;
        }
    }
}
