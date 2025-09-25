namespace Hospital.Services.Abstract
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointments>> GetAppointmentsByPatientIdAsync(int patientId);
        Task<IEnumerable<Appointments>> GetAppointmentsByDoctorIdAsync(int doctorId);
        Task<IEnumerable<Appointments>> GetTodayAppointmentsAsync();
        Task<Appointments> UpdateAppointmentStatusAsync(Appointments appointments);
        Task<bool> IsDoctorAvailableAsync(int doctorId, DateTime appointmentDate);
        Task<IEnumerable<Appointments>> GetAllAppointmentsAsync();

    }
}
