using Hospital.core.Base;
using Hospital.core.Features.Doctor.Query.Response;
using MediatR;

namespace Hospital.core.Features.Doctor.Query.Models
{
    public class GetDoctorListQuery : IRequest<Response<List<GetDoctorsListResponse>>>
    {
    }
}
