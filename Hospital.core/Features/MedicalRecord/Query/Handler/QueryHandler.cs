using AutoMapper;
using Hospital.core.Base;
using Hospital.core.Features.MedicalRecord.Query.Modle;
using Hospital.core.Features.MedicalRecord.Query.Response;
using Hospital.Services.Abstract;
using MediatR;

namespace Hospital.core.Features.MedicalRecord.Query.Handler
{
    public class QueryHandler : ResponseHandler,
        IRequestHandler<GetAllMedicalRecordQuery, Response<List<GetAllMedicalRecordsResponse>>>,
        IRequestHandler<GetMedicalRecordByIdQuery, Response<GetMedicalRecordByIdResponse>>,
        IRequestHandler<GetRecordsByPatientIdQuery, Response<List<GetMedicalRecordsByPatientResponse>>>
    {
        private readonly IMedicalRecordService medicalRecordService;
        private readonly IMapper mapper;
        public QueryHandler(IMedicalRecordService medicalRecordService, IMapper mapper)
        {
            this.medicalRecordService = medicalRecordService;
            this.mapper = mapper;
        }
        public async Task<Response<List<GetAllMedicalRecordsResponse>>> Handle(GetAllMedicalRecordQuery request, CancellationToken cancellationToken)
        {
            var response = await medicalRecordService.GetAllMedicalRecordsAsync();
            var responseMapping = mapper.Map<List<GetAllMedicalRecordsResponse>>(response);
            return Success(responseMapping);
        }

        public async Task<Response<GetMedicalRecordByIdResponse>> Handle(GetMedicalRecordByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await medicalRecordService.GetMedicalRecordByIdAsync(request.Id);
            var ResponseMapping = mapper.Map<GetMedicalRecordByIdResponse>(response);
            return Success(ResponseMapping);
        }

        public async Task<Response<List<GetMedicalRecordsByPatientResponse>>> Handle(GetRecordsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            var response = await medicalRecordService.GetMedicalRecordsByPatientIdAsync(request.PatientId);
            var ResponseMapping = mapper.Map<List<GetMedicalRecordsByPatientResponse>>(response);
            return Success(ResponseMapping);
        }
    }
}
