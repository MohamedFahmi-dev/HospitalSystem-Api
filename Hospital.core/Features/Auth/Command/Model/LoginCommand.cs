using Hospital.core.Base;
using Hospital.core.Features.Auth.Query.Response;
using MediatR;

namespace Hospital.core.Features.Auth.Command.Model
{
    public class LoginCommand : IRequest<Response<LoginResponse>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
