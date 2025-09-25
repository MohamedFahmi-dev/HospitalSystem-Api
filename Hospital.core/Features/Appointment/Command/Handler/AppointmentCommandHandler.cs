using AutoMapper;
using Hospital.core.Base;
using Hospital.core.Features.Appointment.Command.Model;
using Hospital.Services.Abstract;
using MediatR;
using System.Net;

namespace Hospital.core.Features.Appointment.Command.Handler
{
    public class AppointmentCommandHandler : ResponseHandler,
        IRequestHandler<UpdateAppointmentCommand, Response<Appointments>>
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IMapper mapper;

        public AppointmentCommandHandler(IAppointmentService appointmentService, IMapper mapper)
        {
            _appointmentService = appointmentService;
            this.mapper = mapper;
        }

        public async Task<Response<Appointments>> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var response = mapper.Map<Appointments>(request);
            var UpdatedAppointment = await _appointmentService.UpdateAppointmentStatusAsync(response);
            return new Response<Appointments>
            {

                Data = UpdatedAppointment,
                Succeeded = true,
                Message = "Appointment updated successfully",
                StatusCode = HttpStatusCode.OK
            };
        }
    }

}
