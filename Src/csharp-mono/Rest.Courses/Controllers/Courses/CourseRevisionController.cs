using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Courses.Commands.AddCourseRevision;
using Application.Courses.Queries.GetCourseRevisionDetail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Rest.Courses.Controllers.Courses {
    [Route ("api/v1/[controller]")]
    [ApiController]
    public class CourseRevisionController : BaseController {
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddCourseRevision ([FromBody] AddCourseRevisionCommand command) {
            var result = await _mediator.Send (command);
            return StatusCode (result.ReturnCode, result);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetCourseRevisionDetail ([FromBody] long RevisionId) {
            var result = await _mediator.Send (new GetCourseRevisionDetailQuery {
                RevisionId = RevisionId
            });
            return StatusCode (result.ReturnCode, result);
        }
    }
}