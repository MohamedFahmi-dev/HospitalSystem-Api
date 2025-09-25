using Hospital.core.Base;
using MediatR;

namespace Hospital.core.Features.Patient.Command.Models
{
    public class DeletePatientCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }

    }
}
