using Microsoft.AspNetCore.Identity;

namespace HospitalSystem.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName;
        public string LastName;
    }
}
