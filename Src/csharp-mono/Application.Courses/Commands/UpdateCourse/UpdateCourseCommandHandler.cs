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

namespace Application.Courses.Commands.UpdateCourse
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, ApiResponse>
    {
        private readonly IBridgeDbContext _dbContext;
        private readonly ICurrentUserService _userService;
        public UpdateCourseCommandHandler(IBridgeDbContext dbContext, ICurrentUserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }
        public async Task<ApiResponse> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            ApiResponse res = new ApiResponse();

            try
            {
                var userId = _userService.UserId;
                Course obj = await _dbContext.Course.FirstOrDefaultAsync(x => x.Id == request.Id && x.IsDeleted == false);
                if (obj != null)
                {
                    obj.Name = request.Name;
                    obj.Code = request.Code;
                    obj.Description = request.Description;
                    obj.Status = request.Status;
                    obj.Culture = request.Culture;
                    obj.TeacherId = request.TeacherId;
                    obj.LastModificationTime = DateTime.Now.ToString();
                    obj.LastModifierUserId = userId;
                    await _dbContext.SaveChangesAsync(cancellationToken);

                    var responseModel = new
                    {
                        Name = obj.Name,
                        Id = int.Parse(obj.Id.ToString()),
                        Code = obj.Code,
                        Description = obj.Description,
                        Image = obj.Image,
                    };

                    res.data = responseModel;
                    res.response_code = 0;
                    res.message = "Course updated";
                    res.status = "Success";
                    res.ReturnCode = 200;
                }
                else
                {
                    res.response_code = 1;
                    res.message = "No data found";
                    res.status = "Success";
                    res.ReturnCode = 404;
                }
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