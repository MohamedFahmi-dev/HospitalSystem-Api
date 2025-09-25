using Hospital.Data.Enum;

namespace Hospital.Services.Abstract
{
    public interface IDoctorService
    {
        public Task<List<Doctors>> GetDoctorList();
        public Task<Doctors> GetDoctorById(int id);
        public Task<string> CreateDoctor(Doctors doctors);
        public Task<Doctors> EditDoctor(Doctors doctors);
        public Task<string> DeleteDoctor(int id);
        public IQueryable<Doctors> FilterDoctorPaginatedQuerable(DoctorOrder orderby, string search);

    }
}
