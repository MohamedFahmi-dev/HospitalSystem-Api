using AutoMapper;
using Hospital.core.Base;
using Hospital.core.Features.Patient.Command.Models;
using Hospital.Data.Models;
using Hospital.Services.Abstract;
using MediatR;

namespace Hospital.core.Features.Patient.Command.Handler
{
    public class PatientsCommandHandler : ResponseHandler,
        IRequestHandler<CreatePatientsCommand, Response<string>>,
        IRequestHandler<EditPatientsCommand, Response<Patients>>,
        IRequestHandler<DeletePatientCommand, Response<string>>
    {
        #region Fields
        private readonly IpatientService patientservice;
        private readonly IMapper mapper;
        #endregion
        #region constructor
        public PatientsCommandHandler(IpatientService patient, IMapper mapper)
        {
            this.patientservice = patient;
            this.mapper = mapper;
        }

        public async Task<Response<string>> Handle(CreatePatientsCommand request, CancellationToken cancellationToken)
        {
            var patientMapper = mapper.Map<Patients>(request);
            var result = await patientservice.CreatePatients(patientMapper);
            if (result == "Patient already exists") return UnprocessableEntity<String>("Name is Exist");
            else if (result == "success") return Created("Added sucssessfully");
            else return BadRequest<String>("Something went wrong");

        }

        public async Task<Response<Patients>> Handle(EditPatientsCommand request, CancellationToken cancellationToken)
        {
            var patient = mapper.Map<Patients>(request);

            var updatedPatient = await patientservice.EditPatients(patient);
            return new Response<Patients>
            {
                Data = updatedPatient,
                Succeeded = true,
                Message = "Patient updated successfully"

            };
        }

        public async Task<Response<string>> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await patientservice.GetPatientsById(request.Id);
            if (patient == null)
            {
                throw new Exception("Invalid id or Patient not exist");
            }
            await patientservice.DeletePatients(request.Id);
            return new Response<string>("Success", "Patient deleted successfully");

        }
        #endregion
    }
}
