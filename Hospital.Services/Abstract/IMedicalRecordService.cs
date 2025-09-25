namespace Hospital.Services.Abstract
{
    public interface IMedicalRecordService
    {
        Task<IEnumerable<MedicalRecords>> GetAllMedicalRecordsAsync();
        Task<MedicalRecords> GetMedicalRecordByIdAsync(int id);
        Task<string> CreateMedicalRecordAsync(MedicalRecords medicalRecord);
        Task<MedicalRecords> UpdateMedicalRecordAsync(MedicalRecords medicalRecord);
        Task<string> DeleteMedicalRecordAsync(int id);
        public Task<IEnumerable<MedicalRecords>> GetMedicalRecordsByPatientIdAsync(int patientId);

    }
}
