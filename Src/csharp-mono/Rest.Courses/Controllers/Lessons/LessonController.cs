using System.Threading.Tasks;
using Application.Courses.Queries.GetLessonByChapterId;
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
        [HttpGet]
        public async Task<IActionResult> GetLessonsByChapterId(long Id)
        {
            var result = await _mediator.Send(new GetLessonsByChapterIdQuery { Id = Id });

            return Ok(result);
        }

        [Authorize (Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> AddNewLesson([FromBody] AddNewLessonCommand command)
        {
            var result=  await _mediator.Send(command);
            return Ok(result);
        }

    }
}