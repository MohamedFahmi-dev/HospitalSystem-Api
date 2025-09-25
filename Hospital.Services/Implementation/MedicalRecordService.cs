using AutoMapper;
using Hospital.Infrastructure.Abstract;
using Hospital.Services.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Services.Implementation
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly IMedicalRecord medicalService;
        private readonly IMapper mapper;
        public MedicalRecordService(IMedicalRecord medical, IMapper mapper)
        {
            this.medicalService = medical;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<MedicalRecords>> GetAllMedicalRecordsAsync()
        {
            var response = await medicalService.GetTableNoTracking().Include(x => x.Patient).ToListAsync();
            return response;
        }
        public async Task<MedicalRecords> GetMedicalRecordByIdAsync(int Id)
        {
            var response = await medicalService.GetTableNoTracking()
                   .Include(x => x.Patient)
                 .FirstOrDefaultAsync(x => x.Id == Id);
            if (response == null)
            {
                throw new Exception("Medical record not found");
            }
            return response;

        }
        public async Task<IEnumerable<MedicalRecords>> GetMedicalRecordsByPatientIdAsync(int patientId)
        {
            var response = await medicalService.GetTableNoTracking()
                .Include(x => x.Patient)
                .Where(m => m.PatientId == patientId)
                .OrderByDescending(m => m.VisitDate)
                .ToListAsync();
            return response;
        }

        public async Task<String> CreateMedicalRecordAsync(MedicalRecords medicalRecord)
        {
            await medicalService.AddAsync(medicalRecord);
            return "Medical record created successfully";
        }
        public async Task<MedicalRecords> UpdateMedicalRecordAsync(MedicalRecords medicalRecord)
        {
            var patient = await medicalService.GetByIdAsync(medicalRecord.Id);
            if (patient == null)
            {
                throw new Exception("Error MedicalRecords not exist");
            }
            mapper.Map(medicalRecord, patient);

            await medicalService.UpdateAsync(patient);
            return patient;
        }
        public async Task<string> DeleteMedicalRecordAsync(int id)
        {
            var response = await medicalService.GetByIdAsync(id);
            await medicalService.DeleteAsync(response);
            return "Medical record deleted successfully";
        }


    }
}
