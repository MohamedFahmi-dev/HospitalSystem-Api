using AutoMapper;
using Hospital.core.Base;
using Hospital.core.Features.Doctor.Command.Models;
using Hospital.Services.Abstract;
using MediatR;
using System.Net;

namespace Hospital.core.Features.Doctor.Command.Hnadler
{
    public class DocotrsCommandHandler : ResponseHandler,
        IRequestHandler<CreateDoctorCommand, Response<string>>,
        IRequestHandler<UpdateDoctorCommand, Response<Doctors>>,
        IRequestHandler<DeleteDoctorCommand, Response<string>>
    {
        private readonly IDoctorService DoctorService;
        private readonly IMapper mapper;
        public DocotrsCommandHandler(IDoctorService DoctorService, IMapper mapper)
        {
            this.mapper = mapper;
            this.DoctorService = DoctorService;
        }
        public async Task<Response<string>> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            var DoctorMapper = mapper.Map<Doctors>(request);
            var result = await DoctorService.CreateDoctor(DoctorMapper);
            if (result == "Doctor with this email already exists") return UnprocessableEntity<String>("Email is Exist");
            else if (result == "success") return Created("Added sucssessfully");
            else return BadRequest<String>("Something went wrong");
        }

        public async Task<Response<Doctors>> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            var response = mapper.Map<Doctors>(request);

            var UpdatedResopnse = await DoctorService.EditDoctor(response);
            return new Response<Doctors>
            {
                Data = UpdatedResopnse,
                Succeeded = true,
                Message = "Doctor updated successfully",
                StatusCode = HttpStatusCode.OK

            };
        }

        public async Task<Response<string>> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            var response = await DoctorService.GetDoctorById(request.Id);
            if (response == null)
            {
                throw new Exception("Invalid Id or Doctor not exist");

            }
            await DoctorService.DeleteDoctor(response.Id);
            return new Response<string>
            {
                Message = "Doctor deleted successfully",
                Succeeded = true,
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}
