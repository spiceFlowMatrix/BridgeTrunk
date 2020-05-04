using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Application.Courses.Commands.AddNewLesson;

namespace Rest.Courses.Controllers.Lessons
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LessonController : BaseController
    {

        [Authorize (Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> AddNewLesson([FromBody] AddNewLessonCommand command)
        {
            var result=  await _mediator.Send(command);
            return Ok(result);
        }

    }
}