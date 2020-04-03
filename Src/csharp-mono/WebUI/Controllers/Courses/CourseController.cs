using System.Threading.Tasks;
using Application.Courses.Commands.AddEditCourseGrade;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers.Courses
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CourseController  : BaseController
    {
        [HttpPost]
        [Route("CourseGrade")]
        public async Task<IActionResult> PostCourseGrade([FromBody] AddEditCourseGradeCommand command)
        {
            var result= await _mediator.Send(command);
            return Ok(result);            
        }
    }
}