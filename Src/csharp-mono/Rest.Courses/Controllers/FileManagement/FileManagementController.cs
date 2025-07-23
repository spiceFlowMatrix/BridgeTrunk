using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Rest.Courses.Controllers;
using Application.Courses.Queries.GetSignedUrl;
using Application.Courses.Commands.AddUploadedFileInfo;

namespace REST.Courses.Controllers.FileManagement
{
    [Route ("api/v1/[controller]")]
    [ApiController]
    public class FileManagementController : BaseController
    {
        [HttpPost]
        [Authorize (Roles = "admin")]
        public async Task<IActionResult> GetSignedURL([FromBody]GetSignedURLQuery query)
        {
            var result= await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        [Authorize (Roles = "admin")]
        public async Task<IActionResult> AddUploadedFileInfo([FromBody]AddUploadedFileInfoCommand command)
        {
            var result=  await _mediator.Send(command);
            return Ok(result);
        }
    }
}