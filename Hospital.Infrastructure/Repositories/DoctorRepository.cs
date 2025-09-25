using Hospital.Infrastructure.Abstract;
using Hospital.Infrastructure.InfrastructureBase;
using HospitalSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories
{
    public class DoctorRepository : GenericRepos<Doctors>, IDcotor
    {
        private readonly DbSet<Doctors> Doctors;
        public DoctorRepository(AppDbContext context) : base(context)
        {
            Doctors = context.Set<Doctors>();
        }

    }
}
