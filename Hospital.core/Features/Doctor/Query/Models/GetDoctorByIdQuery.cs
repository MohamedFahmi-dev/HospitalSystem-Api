using Hospital.core.Base;
using Hospital.core.Features.Doctor.Query.Response;
using MediatR;

namespace Hospital.core.Features.Doctor.Query.Models
{
    public class GetDoctorByIdQuery : IRequest<Response<GetSingleDoctorResponse>>
    {
        public int Id { get; set; }
        public GetDoctorByIdQuery(int id)
        {
            Id = id;
        }
    }
}
