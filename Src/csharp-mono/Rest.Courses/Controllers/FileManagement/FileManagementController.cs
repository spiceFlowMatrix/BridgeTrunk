using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Rest.Courses.Controllers;
using Application.Courses.Queries.GetSignedUrl;

namespace REST.Courses.Controllers.FileManagement
{
    [Route ("api/v1/[controller]")]
    [ApiController]
    public class FileManagementController : BaseController
    {
        [HttpPost]
        public async Task<object> GetSignedURL([FromBody]GetSignedURLQuery query)
        {
            return await _mediator.Send(query);
        }
    }
}