using Hospital.core.Base;
using MediatR;

namespace Hospital.core.Features.MedicalRecord.Command.Model
{
    public class DeleteMedicalRecordCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }

        public DeleteMedicalRecordCommand(int id)
        {
            Id = id;
        }
    }
}
