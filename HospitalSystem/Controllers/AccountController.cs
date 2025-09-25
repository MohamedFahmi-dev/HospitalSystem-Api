using Hospital.core.Features.Auth.Command.Model;
using Hospital.Data.AppRouting;
using HospitalSystem.Base;
using Microsoft.AspNetCore.Mvc;

namespace HospitalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : AppControllerBase
    {
        [HttpPost(Router.AccountRouting.Register)]
        public async Task<IActionResult> Register([FromBody] RegisterCommand command)
        {

            var result = await Mediator.Send(command);
            return NewResult(result);

        }

        [HttpPost(Router.AccountRouting.Login)]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {

            var result = await Mediator.Send(command);
            return NewResult(result);

        }

    }
}
