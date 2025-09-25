using AutoMapper;
using Hospital.core.Base;
using Hospital.core.Features.Appointment.Query.Model;
using Hospital.core.Features.Appointment.Query.Response;
using Hospital.Services.Abstract;
using MediatR;

namespace Hospital.core.Features.Appointment.Query.Handler
{
    public class AppointmentHandler : ResponseHandler,
        IRequestHandler<GetAppointmentsByDoctorQuery, Response<List<GetAppointmentsByDoctorResponse>>>,
        IRequestHandler<GetAppointmentsByPatientQuery, Response<List<GetAppointmentsByPatientResponse>>>,
        IRequestHandler<GetTodayAppointmentsQuery, Response<List<GetTodayAppointmentsResponse>>>,
        IRequestHandler<IsDoctorAvailableQuery, Response<bool>>,
     IRequestHandler<GetAllAppointmentsQuery, Response<List<GetAllAppointmentsResponse>>>
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IMapper _mapper;

        public AppointmentHandler(IAppointmentService appointmentService, IMapper mapper)
        {
            _appointmentService = appointmentService;
            _mapper = mapper;
        }
        public async Task<Response<List<GetAppointmentsByDoctorResponse>>> Handle(GetAppointmentsByDoctorQuery request, CancellationToken cancellationToken)
        {
            var response = await _appointmentService.GetAppointmentsByDoctorIdAsync(request.DoctorId);
            var appointmapping = _mapper.Map<List<GetAppointmentsByDoctorResponse>>(response);
            return Success(appointmapping);
        }

        public async Task<Response<List<GetAppointmentsByPatientResponse>>> Handle(GetAppointmentsByPatientQuery request, CancellationToken cancellationToken)
        {
            var response = await _appointmentService.GetAppointmentsByPatientIdAsync(request.PatientId);
            var appointmentmap = _mapper.Map<List<GetAppointmentsByPatientResponse>>(response);
            return Success(appointmentmap);
        }

        public async Task<Response<List<GetTodayAppointmentsResponse>>> Handle(GetTodayAppointmentsQuery request, CancellationToken cancellationToken)
        {
            var response = await _appointmentService.GetTodayAppointmentsAsync();
            var mapping = _mapper.Map<List<GetTodayAppointmentsResponse>>(response);
            return Success(mapping);
        }

        public async Task<Response<bool>> Handle(IsDoctorAvailableQuery request, CancellationToken cancellationToken)
        {
            var isAvailable = await _appointmentService.IsDoctorAvailableAsync(request.DoctorId, request.AppointmentDate);
            if (isAvailable)
            {
                return Success(isAvailable, message: $"Doctor is available on {request.AppointmentDate:yyyy-MM-dd HH:mm}");
            }
            else
            {
                return Success(isAvailable, message: $"Doctor is not available on {request.AppointmentDate:yyyy-MM-dd HH:mm}");
            }
        }

        public async Task<Response<List<GetAllAppointmentsResponse>>> Handle(GetAllAppointmentsQuery request, CancellationToken cancellationToken)
        {
            var appointments = await _appointmentService.GetAllAppointmentsAsync();
            var response = _mapper.Map<List<GetAllAppointmentsResponse>>(appointments);
            return Success(response);
        }
    }
}
