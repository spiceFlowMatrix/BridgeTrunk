using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.Courses.Commands.UpsertCourseDefinition;
using Application.Courses.Commands.DeleteCourseDefination;
using Application.Courses.Queries.GetCourseDefinitionById;
using Application.Courses.Queries.GetCourseDefinition;
using Application.Courses.Queries.GetCourseDefinitionSubject;

namespace Rest.Courses.Controllers.Courses
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CourseDefinationController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UpsertCourseDefinationCommand CourseDefination)
        {
            var result = await _mediator.Send(CourseDefination);
            return StatusCode(result.ReturnCode, result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           var result= await _mediator.Send(new DeleteCourseDefinationCommand{
                Id=id
            });
            return StatusCode(result.ReturnCode, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
             var result= await _mediator.Send(new GetCourseDefinitionByIdQuery {
                Id=id
            });
            return StatusCode(result.ReturnCode, result);

        }

        [HttpGet]
        public async Task<IActionResult> Get(int pagenumber, int perpagerecord, string search)
        {
            var result= await _mediator.Send(new GetCourseDefinitionQuery {
                Search = search,
                Pagenumber = pagenumber,
                Perpagerecord = perpagerecord
            });
            return StatusCode(result.ReturnCode, result);
        }

        [HttpGet("GetSubject")]
        public async Task<IActionResult> GetSubject(string search)
        {
            var result= await _mediator.Send(new GetCourseDefinitionSubjectQuery {
              Search = search
            });
            return StatusCode(result.ReturnCode, result);
        }
    }
}