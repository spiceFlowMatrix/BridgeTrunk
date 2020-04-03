using System.Threading.Tasks;
using Application.Courses.Commands.UpsertCourseGrade;
using Microsoft.AspNetCore.Mvc;

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
            return StatusCode(200,result);            
        }
    }
}