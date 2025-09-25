using Hospital.core.Features.Patient.Queries.Response;
using Hospital.core.Pagination;
using Hospital.Data.Enum;
using MediatR;

namespace Hospital.core.Features.Patient.Queries.Models
{
    public class GetPatientPaginatedListQuery : IRequest<PaginatedResult<GetPatientPaginatedListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public PatientOrder orderby { get; set; }
        public string? Search { get; set; }
    }
}
