using Hospital.core.Features.Appointment.Command.Model;
using Hospital.core.Features.Appointment.Query.Model;
using Hospital.Data.AppRouting;
using HospitalSystem.Base;
using Microsoft.AspNetCore.Mvc;

namespace HospitalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : AppControllerBase
    {
        [HttpGet(Router.AppointmentRouting.GetByDoctorId)]
        public async Task<IActionResult> GetAllByDoctorId(int doctorId)
        {
            var response = await Mediator.Send(new GetAppointmentsByDoctorQuery(doctorId));
            return NewResult(response);
        }
        [HttpGet(Router.AppointmentRouting.GetByPatientId)]
        public async Task<IActionResult> GetAllByPatientId(int patientId)
        {
            var response = await Mediator.Send(new GetAppointmentsByPatientQuery(patientId));
            return NewResult(response);
        }
        [HttpGet(Router.AppointmentRouting.GetAll)]

        public async Task<IActionResult> GetAllAppointments()
        {
            var response = await Mediator.Send(new GetAllAppointmentsQuery());
            return NewResult(response);
        }
        [HttpGet(Router.AppointmentRouting.GetTodayAppointments)]
        public async Task<IActionResult> GetTodayAppointments()
        {
            var response = await Mediator.Send(new GetTodayAppointmentsQuery());
            return NewResult(response);
        }
        [HttpGet(Router.AppointmentRouting.CheckDoctorAvailability)]
        public async Task<IActionResult> CheckDoctorAvailability(int doctorId, DateTime appointmentDate)
        {
            var response = await Mediator.Send(new IsDoctorAvailableQuery(doctorId, appointmentDate));
            return NewResult(response);
        }
        [HttpPut(Router.AppointmentRouting.Update)]
        public async Task<IActionResult> UpdateAppointment(UpdateAppointmentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

    }
}
