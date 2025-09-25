using Hospital.Data.Models;
using Hospital.Infrastructure.InfrastructureBase;

namespace Hospital.Infrastructure.Abstract
{
    public interface IPatient : IGenericRepos<Patients>
    {
        public Task<List<Patients>> GetAllPatients();

    }
}
