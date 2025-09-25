using Hospital.Infrastructure.Abstract;
using Hospital.Infrastructure.InfrastructureBase;
using HospitalSystem.Data;
using HospitalSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories
{
    public class AuthRepository : GenericRepos<AppUser>, IAuth
    {
        private readonly DbSet<AppUser> user;
        private readonly UserManager<AppUser> userManager;
        public AuthRepository(AppDbContext dbContext, UserManager<AppUser> userManager) : base(dbContext)
        {
            user = dbContext.Set<AppUser>();
            this.userManager = userManager;
        }

        public async Task<bool> CheckPasswordAsync(AppUser user, string password)
        {
            return await userManager.CheckPasswordAsync(user, password);
        }

        public async Task<AppUser> GetUserByEmailAsync(string email)
        {

            return await userManager.FindByEmailAsync(email);
        }
    }
}
