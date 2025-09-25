using Hospital.core.Base;
using MediatR;

namespace Hospital.core.Features.Doctor.Command.Models
{
    public class DeleteDoctorCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }

    }
}
