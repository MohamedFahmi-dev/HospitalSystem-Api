using Hospital.Infrastructure.InfrastructureBase;
using HospitalSystem.Models;

namespace Hospital.Infrastructure.Abstract
{
    public interface IAuth : IGenericRepos<AppUser>
    {
        Task<AppUser> GetUserByEmailAsync(string email);
        Task<bool> CheckPasswordAsync(AppUser user, string password);
    }
}
