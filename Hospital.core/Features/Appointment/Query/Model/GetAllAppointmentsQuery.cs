using Hospital.core.Base;
using Hospital.core.Features.Appointment.Query.Response;
using MediatR;

namespace Hospital.core.Features.Appointment.Query.Model
{
    public class GetAllAppointmentsQuery : IRequest<Response<List<GetAllAppointmentsResponse>>>
    {

    }
}
