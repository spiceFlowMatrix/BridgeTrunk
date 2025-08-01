using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Courses.Commands.AddCourse;
using Application.Courses.Commands.AddCourseGrade;
using Application.Courses.Commands.AddCourseItemProgressSync;
using Application.Courses.Commands.DeleteCourse;
using Application.Courses.Commands.DeleteCourseGrade;
using Application.Courses.Commands.UpdateCourse;
using Application.Courses.Commands.UpdateCourseGrade;
using Application.Courses.Queries.GetAllCoursesDetail;
using Application.Courses.Queries.GetConvertedUrl;
using Application.Courses.Queries.GetCourse;
using Application.Courses.Queries.GetCourseGrade;
using Application.Courses.Queries.GetCourseList;
using Application.Courses.Queries.GetCourseListByGradeId;
using Application.Courses.Queries.GetCoursePreviewById;
using Application.Courses.Queries.GetCoursePreviewGradeWise;
using Application.Courses.Queries.GetPaginatedCourse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Rest.Courses.Controllers.Courses {
    [Route ("api/v1/[controller]")]
    [ApiController]
    public class CourseController : BaseController {
        [Authorize]
        [HttpPost ("CourseItemProgressSync")]
        public async Task<IActionResult> AddCourseItemProgressSyncBusiness ([FromBody] List<AddCourseItemProgressSyncModel> addCourseItemProgressSyncs) {
            AddCourseItemProgressSyncCommand command = new AddCourseItemProgressSyncCommand {
                addCourseItemProgressSyncs = addCourseItemProgressSyncs
            };
            var result = await _mediator.Send (command);
            return StatusCode (result.ReturnCode, result);
        }

        [Authorize (Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AddCourseCommand command)
        {
            var result = await _mediator.Send(command);
            return StatusCode(result.ReturnCode, result);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateCourseCommand command)
        {
            var result = await _mediator.Send(command);
            return StatusCode(result.ReturnCode, result);
        }

        [Authorize (Roles = "admin")]
        [HttpDelete ("{id}")]
        public async Task<IActionResult> Delete (int id) {
            // uses role
            DeleteCourseCommand command = new DeleteCourseCommand { id = id };
            var result = await _mediator.Send (command);
            return StatusCode (result.ReturnCode, result);
        }

        [Authorize (Roles = "admin")]
        [HttpGet ("{id}")]
        public async Task<IActionResult> Get (int id) { // uses role
            GetCourseQuery query = new GetCourseQuery { Id = id };
            var result = await _mediator.Send (query);
            return StatusCode (result.ReturnCode, result);
        }

        //Updated by arjun singh 29/04/2020 
        [Authorize (Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> Get (int pagenumber, int perpagerecord, string search) { // uses role
            GetPaginatedCourseQuery query = new GetPaginatedCourseQuery {
            pageNumber = pagenumber - 1, // because of previous implementation
            perPageRecord = perpagerecord,
            search = search
            };
            var result = await _mediator.Send (query);
            return StatusCode (result.ReturnCode, result);
        }

        //Updated by arjun singh 29/04/2020 
        [Authorize (Roles = "admin")]
        [HttpGet ("GetCourseList")]
        public async Task<IActionResult> GetCourseList (int pagenumber, int perpagerecord, string search) { // uses role
            GetCourseListQuery query = new GetCourseListQuery {

            pageNumber = pagenumber - 1, // because of previous implementation
            perPageRecord = perpagerecord,
            search = search
            };
            var result = await _mediator.Send (query);
            return StatusCode (result.ReturnCode, result);
        }

        [HttpPost]
        [Route ("CourseGrade")]
        public async Task<IActionResult> PostCourseGrade ([FromBody] AddCourseGradeCommand command) {
            var result = await _mediator.Send (command);
            return StatusCode (result.ReturnCode, result);
        }

        [HttpPut]
        [Route ("CourseGrade/{id}")]
        public async Task<IActionResult> PutCourseGrade (int id, UpdateCourseGradeCommand command) {
            command.id = id;
            var result = await _mediator.Send (command);
            return StatusCode (result.ReturnCode, result);
        }

        [HttpDelete]
        [Route ("CourseGrade/{id}")]
        public async Task<IActionResult> DeleteCourseGrade (int id) {
            var result = await _mediator.Send (new DeleteCourseGradeCommand {
                id = id
            });
            return StatusCode (result.ReturnCode, result);
        }

        [HttpGet]
        [Route ("CourseGrade/{id}")]
        public async Task<IActionResult> GetCourseGrade (int id) {
            var result = await _mediator.Send (new GetCourseGradeQuery {
                id = id
            });
            return StatusCode (result.ReturnCode, result);
        }

        [HttpGet]
        [Route ("GetCourseByGradeId/{id}")]
        public async Task<IActionResult> GetCourseGrade (int id, int pagenumber, int perpagerecord) {
            var result = await _mediator.Send (new GetCourseListByGradeIdQuery {
                Id = id,
                    PageNumber = pagenumber,
                    PerPageRecord = perpagerecord
            });
            return StatusCode (result.ReturnCode, result);
        }

        [HttpGet ("CoursePriview/{id}/{studentid?}")]
        public async Task<IActionResult> CoursePriview (long id, long studentid) {
            var result = await _mediator.Send (new GetCoursePreviewByIdQuery {
                Id = id,
                    StudentId = studentid
            });
            return StatusCode (result.ReturnCode, result);
        }

        [HttpGet ("CoursePriviewGradeWise")]
        public async Task<IActionResult> CoursePrviewGradeWise (int pagenumber, int perpagerecord, string search, int gradeid) {
            var result = await _mediator.Send (new GetCoursePreviewGradeWiseQuery {
                PageNumber = pagenumber,
                    PerPageRecord = perpagerecord,
                    Search = search,
                    GradeId = gradeid
            });
            return StatusCode (result.ReturnCode, result);
        }

        [HttpGet ("ConvertedGeneratedUrl")]
        public async Task<IActionResult> ConvertedGeneratedUrl () {
            GetConvertedUrlQuery query = new GetConvertedUrlQuery ();
            var result = await _mediator.Send (query);

            return StatusCode (result.ReturnCode, result);
        }

        [HttpGet ("GetAllDetails")]
        public async Task<IActionResult> GetAllDetails (int pagenumber, int perpagerecord, string filter, string bygrade, string search) {

            var result = await _mediator.Send (new GetAllCoursesDetailQuery {
                Filter = filter,
                    ByGrade = bygrade,
                    Search = search,
                    PageNumber = pagenumber,
                    PerPageRecord = perpagerecord
            });
            return StatusCode (result.ReturnCode, result);
        }
    }
}