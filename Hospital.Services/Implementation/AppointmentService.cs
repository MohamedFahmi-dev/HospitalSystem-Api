using AutoMapper;
using Hospital.Infrastructure.Abstract;
using Hospital.Services.Abstract;
using HospitalSystem.Data.Enum;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Services.Implementation
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointment Appointmentservice;
        private readonly IDcotor _doctorservice;
        private readonly IMapper mapper;

        public AppointmentService(IAppointment appointment, IMapper mapper, IDcotor dcotor)
        {
            this.Appointmentservice = appointment;
            this.mapper = mapper;
            this._doctorservice = dcotor;
        }

        public async Task<IEnumerable<Appointments>> GetAllAppointmentsAsync()
        {
            var response = await Appointmentservice.GetTableNoTracking().Include(a => a.Patient)
                          .Include(a => a.Doctors).ToListAsync();
            return response;

        }

        public async Task<IEnumerable<Appointments>> GetAppointmentsByDoctorIdAsync(int doctorId)
        {
            var response = await Appointmentservice.GetTableNoTracking()
                .Include(d => d.Doctors).Include(p => p.Patient).Where(d => d.DoctorId == doctorId).OrderBy(a => a.AppointmentDate).ToListAsync();
            return response;
        }

        public async Task<IEnumerable<Appointments>> GetAppointmentsByPatientIdAsync(int patientId)
        {
            var response = await Appointmentservice.GetTableNoTracking()
                           .Include(d => d.Doctors).Include(p => p.Patient).Where(d => d.PatientId == patientId).OrderBy(a => a.AppointmentDate).ToListAsync();
            return response;
        }

        public async Task<IEnumerable<Appointments>> GetTodayAppointmentsAsync()
        {
            var response = await Appointmentservice.GetTableAsTracking().Include(d => d.Doctors).Include(p => p.Patient)
                .Where(a => a.AppointmentDate.Date == DateTime.Now).OrderBy(a => a.AppointmentDate).ToListAsync();
            return response;

        }

        public async Task<bool> IsDoctorAvailableAsync(int doctorId, DateTime appointmentDate)
        {
            var response = await _doctorservice.GetByIdAsync(doctorId);
            if (response == null)
                return false;
            var Available = await Appointmentservice.GetTableNoTracking().AnyAsync(a => a.DoctorId == doctorId && a.AppointmentDate.Date == appointmentDate.Date && a.AppointmentDate.Hour == appointmentDate.Hour &&
                              a.Status != Status.Cancelled);
            return !Available;

        }

        public async Task<Appointments> UpdateAppointmentStatusAsync(Appointments appointments)
        {
            var appointment = await Appointmentservice.GetByIdAsync(appointments.Id);
            if (appointment == null)
            {
                throw new Exception("Appointment not found");
            }
            mapper.Map(appointments, appointment);
            appointment.UpdatedAt = DateTime.UtcNow;
            await Appointmentservice.UpdateAsync(appointment);
            return appointment;
        }
    }
}
