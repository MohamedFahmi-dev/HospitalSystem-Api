using Hospital.core.Base;
using Hospital.core.Features.MedicalRecord.Query.Response;
using MediatR;

namespace Hospital.core.Features.MedicalRecord.Query.Modle
{
    public class GetMedicalRecordByIdQuery : IRequest<Response<GetMedicalRecordByIdResponse>>
    {
        public int Id { get; set; }

        public GetMedicalRecordByIdQuery(int id)
        {
            Id = id;
        }
    }
}
