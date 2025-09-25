using HospitalSystem.Models;

namespace Hospital.Services.Abstract
{
    public interface IJwtTokenService
    {
        Task<string> GenerateTokenAsync(AppUser user);

    }
}