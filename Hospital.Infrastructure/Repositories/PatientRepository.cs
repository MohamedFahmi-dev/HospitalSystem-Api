using Hospital.Data.Models;
using Hospital.Infrastructure.Abstract;
using Hospital.Infrastructure.InfrastructureBase;
using HospitalSystem.Data;
using Microsoft.EntityFrameworkCore;
namespace Hospital.Infrastructure.Repositories
{
    public class PatientRepository : GenericRepos<Patients>, IPatient
    {
        #region Fields
        private readonly DbSet<Patients> patients;
        #endregion
        #region constructor
        public PatientRepository(AppDbContext context) : base(context)
        {
            patients = context.Set<Patients>();
        }
        #endregion
        #region Handeles Function
        public async Task<List<Patients>> GetAllPatients()
        {
            return await _dbContext.Patients.Include(p => p.Appointments).ToListAsync();
        }
        #endregion
    }
}
