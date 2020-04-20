using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using MediatR;
using Bridge.Application.Models;
using Bridge.Domain.Entities;
using Bridge.Application.Interfaces;
using Application.Helpers;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Google.Cloud.Storage.V1;
using Google.Apis.Auth.OAuth2;

namespace Application.Courses.Commands.DeleteCourse
{
    public class DeleteCourseCommandHandler: IRequestHandler<DeleteCourseCommand, ApiResponse>
    {
        private readonly IBridgeDbContext _dbContext;
        private readonly ICurrentUserService _userService;
        public DeleteCourseCommandHandler(IBridgeDbContext dbContext, ICurrentUserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }
        public async Task<ApiResponse> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            ApiResponse res = new ApiResponse();
            try
            {
                object returnModel;
                Course course = await _dbContext.Course.FirstOrDefaultAsync(x=>x.IsDeleted == false && x.Id == request.id);
                if(course != null)
                {
                    course.IsDeleted = true;
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    returnModel = new {
                        Name = course.Name,
                        Id = int.Parse(course.Id.ToString()),
                        Code = course.Code,
                        Description = course.Description,
                        Image = course.Image,
                        //TeacherId = newCourse.TeacherId
                    };
                }
                else
                {
                    returnModel = null;
                }

                
                res.data = returnModel;
                res.response_code = 0;
                res.message = "Course Deleted";
                res.status = "Success";
                res.ReturnCode = 200;
            }
            catch (Exception ex)
            {
                res.response_code = 2;
                res.message = ex.Message;
                res.status = "Failure";
                res.ReturnCode = 500;
            }
            return res;
        }
    }
}