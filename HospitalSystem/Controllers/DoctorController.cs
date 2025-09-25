using Hospital.core.Features.Doctor.Command.Models;
using Hospital.core.Features.Doctor.Query.Models;
using Hospital.Data.AppRouting;
using HospitalSystem.Base;
using Microsoft.AspNetCore.Mvc;

namespace HospitalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : AppControllerBase
    {
        [HttpGet(Router.DoctorRouting.GetAll)]
        public async Task<IActionResult> GetAllDoctorList()
        {
            var response = await Mediator.Send(new GetDoctorListQuery());
            return NewResult(response);
        }
        [HttpGet(Router.DoctorRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetDoctorPaginatedListQuery query)
        {
            var respnse = await Mediator.Send(query);
            return Ok(respnse);
        }
        [HttpGet(Router.DoctorRouting.GetById)]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await Mediator.Send(new GetDoctorByIdQuery(id));
            return NewResult(response);
        }
        [HttpPost(Router.DoctorRouting.Create)]
        public async Task<IActionResult> CreateDoctor([FromBody] CreateDoctorCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpPut(Router.DoctorRouting.Update)]
        public async Task<IActionResult> UpdateDoctor([FromBody] UpdateDoctorCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpDelete(Router.DoctorRouting.Delete)]
        public async Task<IActionResult> DeleteDoctor(int Id)
        {
            var response = await Mediator.Send(new DeleteDoctorCommand { Id = Id });
            return NewResult(response);
        }
    }
}
