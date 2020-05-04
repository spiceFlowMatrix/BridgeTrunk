using Microsoft.AspNetCore.Mvc;

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
            return await _mediator.Send(command);
        }

    }
}