using Hospital.Infrastructure.Abstract;
using Hospital.Infrastructure.InfrastructureBase;
using HospitalSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories
{
    public class MedicalRecordRepository : GenericRepos<MedicalRecords>, IMedicalRecord
    {
        private readonly DbSet<MedicalRecords> medicalRecords;
        public MedicalRecordRepository(AppDbContext dbContext) : base(dbContext)
        {
            medicalRecords = dbContext.Set<MedicalRecords>();
        }
    }
}
