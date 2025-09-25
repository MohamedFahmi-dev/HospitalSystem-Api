using Hospital.Infrastructure.Abstract;
using Hospital.Infrastructure.InfrastructureBase;
using HospitalSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories
{
    public class AppointmentRepository : GenericRepos<Appointments>, IAppointment
    {
        private readonly DbSet<Appointments> appointments;
        public AppointmentRepository(AppDbContext context) : base(context)
        {
            appointments = context.Set<Appointments>();
        }
    }
}
