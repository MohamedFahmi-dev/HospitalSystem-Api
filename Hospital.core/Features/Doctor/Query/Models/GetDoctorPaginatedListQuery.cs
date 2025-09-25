using Hospital.core.Features.Doctor.Query.Response;
using Hospital.core.Pagination;
using Hospital.Data.Enum;
using MediatR;

namespace Hospital.core.Features.Doctor.Query.Models
{
    public class GetDoctorPaginatedListQuery : IRequest<PaginatedResult<GetDoctorPaginatedListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public DoctorOrder orderby { get; set; }
        public string? Search { get; set; }
    }
}
