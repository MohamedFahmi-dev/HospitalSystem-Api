using AutoMapper;
using Hospital.core.Base;
using Hospital.core.Features.Doctor.Query.Models;
using Hospital.core.Features.Doctor.Query.Response;
using Hospital.core.Pagination;
using Hospital.Services.Abstract;
using MediatR;
using System.Linq.Expressions;

namespace Hospital.core.Features.Doctor.Query.Handeler
{
    public class DoctorHandler : ResponseHandler,
        IRequestHandler<GetDoctorListQuery, Response<List<GetDoctorsListResponse>>>,
        IRequestHandler<GetDoctorByIdQuery, Response<GetSingleDoctorResponse>>,
        IRequestHandler<GetDoctorPaginatedListQuery, PaginatedResult<GetDoctorPaginatedListResponse>>
    {
        private readonly IDoctorService doctorService;
        private readonly IMapper mapper;
        public DoctorHandler(IDoctorService doctorService, IMapper mapper)
        {
            this.doctorService = doctorService;
            this.mapper = mapper;
        }
        public async Task<Response<List<GetDoctorsListResponse>>> Handle(GetDoctorListQuery request, CancellationToken cancellationToken)
        {
            var response = await doctorService.GetDoctorList();
            var responseMapper = mapper.Map<List<GetDoctorsListResponse>>(response);
            return Success(responseMapper);
        }

        public async Task<Response<GetSingleDoctorResponse>> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await doctorService.GetDoctorById(request.Id);
            var responseMapping = mapper.Map<GetSingleDoctorResponse>(response);
            return Success(responseMapping);
        }

        public async Task<PaginatedResult<GetDoctorPaginatedListResponse>> Handle(GetDoctorPaginatedListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Doctors, GetDoctorPaginatedListResponse>> expression =
                            e => new GetDoctorPaginatedListResponse(e.Id, e.FirstName, e.LastName, e.Specialization, e.PhoneNumber, e.Email, e.YearOfExperience);
            var FilterQuery = doctorService.FilterDoctorPaginatedQuerable(request.orderby, request.Search);
            var paginatedList = await FilterQuery.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedList;

        }
    }
}
