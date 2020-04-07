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
        private readonly IUserHelper _userHelper;
        public DeleteCourseCommandHandler(IBridgeDbContext dbContext, ICurrentUserService userService, IUserHelper userHelper)
        {
            _dbContext = dbContext;
            _userService = userService;
            _userHelper = userHelper;
        }
        public async Task<ApiResponse> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            ApiResponse res = new ApiResponse();
            try
            {
                if (_userService.RoleList.Contains(Roles.admin.ToString()))
                {
                    // Awaiting specification

                    // res.data = responseCourseModel;
                    res.response_code = 0;
                    res.message = "Course Deleted";
                    res.status = "Success";
                    res.ReturnCode = 200;
                }
                else 
                {
                    res.response_code = 1;
                    res.message = "You are not authorized.";
                    res.status = "Unsuccess";
                    res.ReturnCode = 401;
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