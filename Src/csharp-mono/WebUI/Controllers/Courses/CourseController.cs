using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.Courses.Commands.AddCourseGrade;
using Application.Courses.Commands.UpdateCourseGrade;
using Application.Courses.Commands.DeleteCourseGrade;
using Application.Courses.Queries.GetCourseGrade;
using Application.Courses.Queries.GetCourseListByGradeId;
using Application.Courses.Queries.GetCoursePreviewById;

namespace WebUI.Controllers.Courses
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CourseController  : BaseController
    {
        [HttpPost]
        [Route("CourseGrade")]
        public async Task<IActionResult> PostCourseGrade([FromBody] AddCourseGradeCommand command)
        {
            var result= await _mediator.Send(command);
            return StatusCode(result.ReturnCode, result);            
        }

        [HttpPut]
        [Route("CourseGrade/{id}")]
        public async Task<IActionResult> PutCourseGrade(int id, UpdateCourseGradeCommand command)
        {
            var result= await _mediator.Send(command);
            return StatusCode(result.ReturnCode, result);            
        }

        [HttpDelete]
        [Route("CourseGrade/{id}")]
        public async Task<IActionResult> DeleteCourseGrade(int id)
        {
            var result= await _mediator.Send(new DeleteCourseGradeCommand{
                id=id
            });
            return StatusCode(result.ReturnCode, result);
        }

        [HttpGet]
        [Route("CourseGrade/{id}")]
        public async Task<IActionResult> GetCourseGrade(int id)
        {
            var result= await _mediator.Send(new GetCourseGradeQuery {
                id=id
            });
            return StatusCode(result.ReturnCode, result);
        }

        [HttpGet]
        [Route("GetCourseByGradeId/{id}")]
        public async Task<IActionResult> GetCourseGrade(int id, int pagenumber, int perpagerecord)
        {
            var result= await _mediator.Send(new GetCourseListByGradeIdQuery {
                Id=id,
                PageNumber = pagenumber,
                PerPageRecord = perpagerecord
            });
            return StatusCode(result.ReturnCode, result);
        }

        [HttpGet("CoursePriview/{id}/{studentid?}")]
        public async Task<IActionResult> CoursePriview(long id, long studentid)
        {
                var result= await _mediator.Send(new GetCoursePreviewByIdQuery {
                Id = id,
                StudentId = studentid              
            });
            return StatusCode(result.ReturnCode, result);
        }
    }
}
