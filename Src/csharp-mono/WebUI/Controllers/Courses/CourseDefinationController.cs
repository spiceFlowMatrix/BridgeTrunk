using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.Courses.Commands.UpsertCourseDefinition;
namespace WebUI.Controllers.Courses
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CourseDefinationController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UpsertCourseDefinationCommand command)
        {
            var result = await _mediator.Send(command);
            return StatusCode(result.ReturnCode, result);
        }
    }
}