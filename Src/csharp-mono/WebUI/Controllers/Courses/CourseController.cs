using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.Courses.Commands.UpsertCourseGrade;
using Application.Courses.Commands.AddCourseItemProgressSync;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace WebUI.Controllers.Courses
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CourseController  : BaseController
    {
        [Authorize]
        [HttpPost("CourseItemProgressSync")]
        public async Task<IActionResult> AddCourseItemProgressSyncBusiness([FromBody] List<AddCourseItemProgressSyncModel> addCourseItemProgressSyncs)
        {
            AddCourseItemProgressSyncCommand command = new AddCourseItemProgressSyncCommand 
            {
                addCourseItemProgressSyncs = addCourseItemProgressSyncs
            };
            var result= await _mediator.Send(command);
            return StatusCode(result.ReturnCode, result);
        }

        [HttpPost]
        [Route("CourseGrade")]
        public async Task<IActionResult> PostCourseGrade([FromBody] UpsertCourseGradeCommand command)
        {
            var result= await _mediator.Send(command);
            return StatusCode(result.ReturnCode, result);            
        }
    }
}