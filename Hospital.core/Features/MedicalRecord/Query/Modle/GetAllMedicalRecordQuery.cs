using Hospital.core.Base;
using Hospital.core.Features.MedicalRecord.Query.Response;
using MediatR;

namespace Hospital.core.Features.MedicalRecord.Query.Modle
{
    public class GetAllMedicalRecordQuery : IRequest<Response<List<GetAllMedicalRecordsResponse>>>
    {
    }
}
