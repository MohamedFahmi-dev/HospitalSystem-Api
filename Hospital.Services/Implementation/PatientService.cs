using AutoMapper;
using Hospital.Data.Enum;
using Hospital.Data.Models;
using Hospital.Infrastructure.Abstract;
using Hospital.Services.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Services.Implementation
{
    public class PatientService : IpatientService
    {
        private readonly IPatient _patientService;
        private readonly IMapper mapper;

        public PatientService(IPatient ipatientService, IMapper mapper)
        {
            _patientService = ipatientService;
            this.mapper = mapper;
        }
        public async Task<List<Patients>> GetPatientsList()
        {
            return await _patientService.GetAllPatients();

        }
        public async Task<Patients> GetPatientsById(int id)
        {
            // return  await _patientService.GetByIdAsync(id);
            var patint = await _patientService.GetByIdAsync(id);
            if (patint == null)
            {
                throw new Exception("Patient not found");
            }
            return patint;
        }

        public async Task<string> CreatePatients(Patients patients)
        {
            var patient = await _patientService.GetTableNoTracking().FirstOrDefaultAsync(p => p.FirstName == patients.FirstName);
            if (patient != null)
            {
                throw new Exception("Patient already exists");
            }
            await _patientService.AddAsync(patients);
            return "success";
        }

        public async Task<Patients> EditPatients(Patients patients)
        {
            var patient = await _patientService.GetByIdAsync(patients.id);
            if (patient == null)
            {
                throw new Exception("error Patient not exist");
            }
            mapper.Map(patients, patient);

            await _patientService.UpdateAsync(patient);

            return patient;
        }

        public async Task<string> DeletePatients(int id)
        {

            if (id <= 0)
                throw new ArgumentException("Invalid doctor ID", nameof(id));
            var patient = await _patientService.GetByIdAsync(id);
            if (patient == null)
            {
                throw new KeyNotFoundException($"Doctor with ID {id} not found");
            }
            await _patientService.DeleteAsync(patient);
            return "Patient Deleted successfully";
        }

        public IQueryable<Patients> GetPatientsPaginatedList()
        {
            return _patientService.GetTableNoTracking().Include(a => a.Appointments).AsQueryable();
        }

        public IQueryable<Patients> FilterPatientPaginatedQuerable(PatientOrder orderby, string Search)
        {
            var Filter = _patientService.GetTableNoTracking();
            if (!string.IsNullOrEmpty(Search))
            {
                Filter = Filter.Where(x => x.FirstName.Contains(Search) || x.LastName.Contains(Search));
            }
            switch (orderby)
            {
                case PatientOrder.id:
                    Filter = Filter.OrderBy(x => x.id);
                    break;
                case PatientOrder.FirstName:
                    Filter = Filter.OrderBy(x => x.FirstName);
                    break;
                case PatientOrder.LastName:
                    Filter = Filter.OrderBy(x => x.LastName);
                    break;
                case PatientOrder.PhoneNumber:
                    Filter = Filter.OrderBy(x => x.PhoneNumber);
                    break;
                case PatientOrder.Email:
                    Filter = Filter.OrderBy(x => x.Email);
                    break;
                case PatientOrder.AppointmentDate:
                    Filter = Filter.OrderBy(x => x.Appointments.Min(a => a.AppointmentDate));
                    break;
            }
            return Filter;
        }
    }
}

