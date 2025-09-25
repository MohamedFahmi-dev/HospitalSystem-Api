using Hospital.core.Base;
using Hospital.core.Features.MedicalRecord.Query.Response;
using MediatR;

namespace Hospital.core.Features.MedicalRecord.Query.Modle
{
    public class GetRecordsByPatientIdQuery : IRequest<Response<List<GetMedicalRecordsByPatientResponse>>>
    {
        public int PatientId { get; set; }

        public GetRecordsByPatientIdQuery(int patientId)
        {
            PatientId = patientId;
        }
    }
}
