using System.Threading.Tasks;
using Application.Authentication.Commands.CreateUser;
using Application.Authentication.Commands.LoginUser;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers.Authentication
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountController: BaseController
    {
        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}