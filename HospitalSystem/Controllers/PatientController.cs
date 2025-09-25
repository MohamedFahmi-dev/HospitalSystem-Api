using Hospital.core.Features.Patient.Command.Models;
using Hospital.core.Features.Patient.Queries.Models;
using Hospital.Data.AppRouting;
using HospitalSystem.Base;
using Microsoft.AspNetCore.Mvc;
namespace HospitalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : AppControllerBase
    {

        [HttpGet(Router.PatientRouting.GetAll)]
        public async Task<IActionResult> GetAllPatinetList()
        {
            var patient = await Mediator.Send(new GetPatientListQuery());
            return Ok(patient);
        }
        [HttpGet(Router.PatientRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetPatientPaginatedListQuery query)
        {
            var patient = await Mediator.Send(query);
            return Ok(patient);
        }
        [HttpGet(Router.PatientRouting.GetById)]
        public async Task<IActionResult> GetPatinetById(int id)
        {
            var patient = await Mediator.Send(new GetPatientByIdQuery(id));
            return NewResult(patient);
        }
        [HttpPost(Router.PatientRouting.Create)]
        public async Task<IActionResult> CreatePatient([FromBody] CreatePatientsCommand command)
        {
            var patient = await Mediator.Send(command);
            return NewResult(patient);
        }
        [HttpPut(Router.PatientRouting.Update)]
        public async Task<IActionResult> EditPatient([FromBody] EditPatientsCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);

        }
        [HttpDelete(Router.PatientRouting.Delete)]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var response = await Mediator.Send(new DeletePatientCommand { Id = id });
            return Ok(response);
        }
    }
}
