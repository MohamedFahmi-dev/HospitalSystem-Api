using Hospital.core.Features.MedicalRecord.Command.Model;
using Hospital.core.Features.MedicalRecord.Query.Modle;
using Hospital.Data.AppRouting;
using HospitalSystem.Base;
using Microsoft.AspNetCore.Mvc;

namespace HospitalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordController : AppControllerBase
    {
        [HttpGet(Router.MedicalRecordRouting.GetAll)]
        public async Task<IActionResult> GetAllMedicalRecord()
        {
            var response = await Mediator.Send(new GetAllMedicalRecordQuery());
            return NewResult(response);
        }
        [HttpGet(Router.MedicalRecordRouting.GetById)]
        public async Task<IActionResult> GetByIdMedicalRecord(int id)
        {
            var response = await Mediator.Send(new GetMedicalRecordByIdQuery(id));
            return NewResult(response);
        }
        [HttpGet(Router.MedicalRecordRouting.GetByPatientId)]
        public async Task<IActionResult> GetByPatientIdMedicalRecord(int patientId)
        {
            var response = await Mediator.Send(new GetRecordsByPatientIdQuery(patientId));
            return NewResult(response);
        }
        [HttpPost(Router.MedicalRecordRouting.Create)]
        public async Task<IActionResult> CreateMedicalRecord([FromBody] CreateMedicalRecordCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpPut(Router.MedicalRecordRouting.Update)]
        public async Task<IActionResult> UpdateMedicalRecord([FromBody] UpdateMedicalRecordCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpDelete(Router.MedicalRecordRouting.Delete)]
        public async Task<IActionResult> DeleteMedicalRecord(int Id)
        {
            var response = await Mediator.Send(new DeleteMedicalRecordCommand(Id));
            return NewResult(response);
        }
    }
}
