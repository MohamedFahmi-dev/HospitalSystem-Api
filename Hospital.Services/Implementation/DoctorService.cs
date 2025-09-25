using AutoMapper;
using Hospital.Data.Enum;
using Hospital.Infrastructure.Abstract;
using Hospital.Services.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Services.Implementation
{
    class DoctorService : IDoctorService
    {
        private readonly IDcotor _Doctor;
        private readonly IMapper mapper;
        public DoctorService(IDcotor dcotor, IMapper mapper)
        {
            _Doctor = dcotor;
            this.mapper = mapper;
        }
        public async Task<List<Doctors>> GetDoctorList()
        {
            return await _Doctor.GetAllAsync();

        }
        public async Task<Doctors> GetDoctorById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid doctor ID", nameof(id));
            var Responce = await _Doctor.GetTableNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return Responce;

        }
        public async Task<string> CreateDoctor(Doctors doctors)
        {
            var existingDoctor = await _Doctor.GetTableNoTracking().FirstOrDefaultAsync(x => x.Email == doctors.Email);

            if (existingDoctor != null)
            {
                throw new InvalidOperationException("Doctor with this email already exists");
            }
            await _Doctor.AddAsync(doctors);
            return "success";
        }
        public async Task<Doctors> EditDoctor(Doctors doctors)
        {
            var existingDoctor = await _Doctor.GetByIdAsync(doctors.Id);
            if (existingDoctor == null)
            {
                throw new KeyNotFoundException($"Doctor with ID {doctors.Id} not found");
            }
            mapper.Map(doctors, existingDoctor);

            await _Doctor.UpdateAsync(existingDoctor);
            return existingDoctor;

        }
        public async Task<string> DeleteDoctor(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid doctor ID", nameof(id));
            var Responce = await _Doctor.GetByIdAsync(id);
            if (Responce == null)
            {
                throw new KeyNotFoundException($"Doctor with ID {id} not found");
            }
            await _Doctor.DeleteAsync(Responce);
            return "Doctor Deleted Successfully";


        }

        public IQueryable<Doctors> FilterDoctorPaginatedQuerable(DoctorOrder orderby, string search)
        {
            var filter = _Doctor.GetTableNoTracking();
            if (!string.IsNullOrEmpty(search))
            {
                filter = filter.Where(x => x.FirstName.Contains(search) || x.LastName.Contains(search));
            }
            switch (orderby)
            {
                case DoctorOrder.Id:
                    filter = filter.OrderBy(x => x.Id);
                    break;
                case DoctorOrder.FirstName:
                    filter = filter.OrderBy(x => x.FirstName);
                    break;
                case DoctorOrder.LastName:
                    filter = filter.OrderBy(x => x.LastName);
                    break;
                case DoctorOrder.Email:
                    filter = filter.OrderBy(x => x.Email);
                    break;
                case DoctorOrder.PhoneNumber:
                    filter = filter.OrderBy(x => x.PhoneNumber);
                    break;
                case DoctorOrder.Specialization:
                    filter = filter.OrderBy(x => x.Specialization);
                    break;
                case DoctorOrder.YearOfExperience:
                    filter = filter.OrderBy(x => x.YearOfExperience);
                    break;
            }
            return filter;


        }
    }
}
