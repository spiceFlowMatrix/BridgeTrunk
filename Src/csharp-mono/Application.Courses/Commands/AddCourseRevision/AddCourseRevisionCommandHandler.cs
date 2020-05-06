using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Helpers;
using Application.Interfaces;
using Bridge.Application.Interfaces;
using Bridge.Application.Models;
using Bridge.Domain.Entities;
using Domain.Enum;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Courses.Commands.AddCourseRevision {
    public class AddCourseRevisionCommandHandler : IRequestHandler<AddCourseRevisionCommand, ApiResponse> {
        private readonly IBridgeDbContext _dbContext;
        private readonly ICurrentUserService _userService;
        public AddCourseRevisionCommandHandler (IBridgeDbContext dbContext, ICurrentUserService userService) {
            _dbContext = dbContext;
            _userService = userService;
        }

        public async Task<ApiResponse> Handle (AddCourseRevisionCommand request, CancellationToken cancellationToken) 
        {
            ApiResponse res = new ApiResponse ();
            try 
            {
                CourseRevision obj = new CourseRevision
                {
                    RevisionName = request.RevisionName,
                    Summary = request.Summary,
                    CourseId = request.CourseId,
                    Status = (int)RevisionStatus.revision_start,
                    AdministeredOn = DateTime.Now.ToString(),
                    AdministeredBy = _userService.UserId,
                    CreatorUserId = _userService.UserId,
                    CreationTime = DateTime.Now.ToString()
                };
                _dbContext.CourseRevision.Add(obj);
                await _dbContext.SaveChangesAsync(cancellationToken);

                res.response_code = 0;
                res.message = "Revision Created";
                res.status = "Success";
                res.ReturnCode = StatusCodes.Status200OK;
            }
            catch(Exception ex)
            {
                res.response_code = 2;
                res.message = ex.Message;
                res.status = "Failure";
                res.ReturnCode = StatusCodes.Status500InternalServerError;
            }
            return res;
        }
    }
}