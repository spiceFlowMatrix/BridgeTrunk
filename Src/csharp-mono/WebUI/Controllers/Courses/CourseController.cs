using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.Courses.Commands.UpsertCourseGrade;

namespace WebUI.Controllers.Courses
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CourseController  : BaseController
    {
        [HttpPost]
        [Route("CourseGrade")]
        public async Task<IActionResult> PostCourseGrade([FromBody] UpsertCourseGradeCommand command)
        {
            var result= await _mediator.Send(command);
            return StatusCode(result.ReturnCode, result);            
        }
    }
}