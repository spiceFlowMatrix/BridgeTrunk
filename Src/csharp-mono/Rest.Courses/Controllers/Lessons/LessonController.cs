using System.Threading.Tasks;
using Application.Courses.Queries.GetLessonByChapterId;
using Microsoft.AspNetCore.Mvc;

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

    }
}