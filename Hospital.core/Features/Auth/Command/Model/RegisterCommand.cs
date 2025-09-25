using Hospital.core.Base;
using Hospital.core.Features.Auth.Query.Response;
using MediatR;

namespace Hospital.core.Features.Auth.Command.Model
{
    public class RegisterCommand : IRequest<Response<RegisterResponse>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Role { get; set; } = "Patient";
    }
}
