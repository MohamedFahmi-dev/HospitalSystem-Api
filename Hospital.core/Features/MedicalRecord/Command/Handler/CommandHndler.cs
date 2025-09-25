using AutoMapper;
using Hospital.core.Base;
using Hospital.core.Features.MedicalRecord.Command.Model;
using Hospital.Services.Abstract;
using MediatR;
using System.Net;

namespace Hospital.core.Features.MedicalRecord.Command.Handler
{
    public class CommandHndler : ResponseHandler,
        IRequestHandler<CreateMedicalRecordCommand, Response<string>>,
        IRequestHandler<UpdateMedicalRecordCommand, Response<MedicalRecords>>,
        IRequestHandler<DeleteMedicalRecordCommand, Response<string>>
    {
        private readonly IMedicalRecordService medicalRecordService;
        private readonly IMapper mapper;
        public CommandHndler(IMedicalRecordService medicalRecordService, IMapper mapper)
        {
            this.medicalRecordService = medicalRecordService;
            this.mapper = mapper;
        }
        public async Task<Response<string>> Handle(CreateMedicalRecordCommand request, CancellationToken cancellationToken)
        {
            var mapping = mapper.Map<MedicalRecords>(request);
            var response = await medicalRecordService.CreateMedicalRecordAsync(mapping);
            if (response == "Medical record created successfully") return Created("Added Sucessfully");
            else return BadRequest<string>("Something went wrong");

        }

        public async Task<Response<MedicalRecords>> Handle(UpdateMedicalRecordCommand request, CancellationToken cancellationToken)
        {
            var Mapping = mapper.Map<MedicalRecords>(request);
            var response = await medicalRecordService.UpdateMedicalRecordAsync(Mapping);
            return new Response<MedicalRecords>
            {
                Data = response,
                Succeeded = true,
                Message = "Medical Record Updated SuccessFully",
                StatusCode = HttpStatusCode.OK
            };
        }

        public async Task<Response<string>> Handle(DeleteMedicalRecordCommand request, CancellationToken cancellationToken)
        {
            var response = await medicalRecordService.GetMedicalRecordByIdAsync(request.Id);
            if (response == null)
            {
                return NotFound<string>("Medical record not found");

            }
            await medicalRecordService.DeleteMedicalRecordAsync(request.Id);
            return new Response<string>
            {
                Message = "Medical record deleted successfully",
                Succeeded = true,
                StatusCode = HttpStatusCode.OK
            };

        }
    }
}
