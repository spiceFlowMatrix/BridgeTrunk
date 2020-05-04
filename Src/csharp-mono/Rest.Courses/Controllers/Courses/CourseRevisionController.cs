using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Courses.Commands.AddCourseRevision;

namespace Rest.Courses.Controllers.Courses {
    [Route ("api/v1/[controller]")]
    [ApiController]
    public class CourseRevisionController : BaseController {
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddCourseRevision([FromBody] AddCourseRevisionCommand command)
        {
            var result = await _mediator.Send(command);
            return StatusCode(result.ReturnCode, result);
        }
    }
}