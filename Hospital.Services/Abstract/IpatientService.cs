using Hospital.Data.Enum;
using Hospital.Data.Models;

namespace Hospital.Services.Abstract
{
    public interface IpatientService
    {
        public Task<List<Patients>> GetPatientsList();
        public Task<Patients> GetPatientsById(int id);
        public Task<string> CreatePatients(Patients patients);
        public Task<Patients> EditPatients(Patients patients);
        public Task<string> DeletePatients(int id);
        public IQueryable<Patients> GetPatientsPaginatedList();
        public IQueryable<Patients> FilterPatientPaginatedQuerable(PatientOrder orderby, string search);




    }
}
