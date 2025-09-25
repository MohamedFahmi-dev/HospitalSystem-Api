using AutoMapper;
using Hospital.core.Base;
using Hospital.core.Features.Patient.Queries.Models;
using Hospital.core.Features.Patient.Queries.Response;
using Hospital.core.Pagination;
using Hospital.Data.Models;
using Hospital.Services.Abstract;
using MediatR;
using System.Linq.Expressions;

namespace Hospital.core.Features.Patient.Queries.Handler
{
    public class PatientHandler : ResponseHandler,
         IRequestHandler<GetPatientListQuery, Response<List<PatientListResponse>>>,
         IRequestHandler<GetPatientByIdQuery, Response<GetSinglePatientResponse>>,
         IRequestHandler<GetPatientPaginatedListQuery, PaginatedResult<GetPatientPaginatedListResponse>>
    {
        #region Fields
        private readonly IpatientService PatientService;
        private readonly IMapper mapper;
        #endregion
        #region constructor
        public PatientHandler(IpatientService PatientService, IMapper mapper)
        {
            this.PatientService = PatientService;
            this.mapper = mapper;
        }
        #endregion
        #region Handle Method
        public async Task<Response<List<PatientListResponse>>> Handle(GetPatientListQuery request, CancellationToken cancellationToken)
        {
            var PatientList = await PatientService.GetPatientsList();
            var PatientListMapper = mapper.Map<List<PatientListResponse>>(PatientList);
            return Success(PatientListMapper);
        }

        public async Task<Response<GetSinglePatientResponse>> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            var Singlepatient = await PatientService.GetPatientsById(request.Id);
            var patientMapper = mapper.Map<GetSinglePatientResponse>(Singlepatient);
            return Success(patientMapper);
        }

        public async Task<PaginatedResult<GetPatientPaginatedListResponse>> Handle(GetPatientPaginatedListQuery request, CancellationToken cancellationToken)
        {

            Expression<Func<Patients, GetPatientPaginatedListResponse>> expression
                = e => new GetPatientPaginatedListResponse(e.id, e.FirstName, e.LastName, e.PhoneNumber, e.Email, e.Appointments.Select(e => e.AppointmentDate).FirstOrDefault());
            var FilterQuery = PatientService.FilterPatientPaginatedQuerable(request.orderby, request.Search);
            var paginatedList = await FilterQuery.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedList;
        }
        #endregion

    }
}
