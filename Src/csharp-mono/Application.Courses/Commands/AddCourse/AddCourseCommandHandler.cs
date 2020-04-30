using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Application.Helpers;
using Application.Interfaces;
using Bridge.Application.Interfaces;
using Bridge.Application.Models;
using Bridge.Domain.Entities;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Courses.Commands.AddCourse {
    public class AddCourseCommandHandler : IRequestHandler<AddCourseCommand, ApiResponse> {
        private readonly IBridgeDbContext _dbContext;
        private readonly ICurrentUserService _userService;
        public AddCourseCommandHandler (IBridgeDbContext dbContext, ICurrentUserService userService) {
            _dbContext = dbContext;
            _userService = userService;
        }

        public async Task<ApiResponse> Handle (AddCourseCommand request, CancellationToken cancellationToken) {
            
            ApiResponse res = new ApiResponse ();

            try 
            {
                string userId = _userService.UserId;

                Course obj = new Course 
                {
                    Name = request.Name,
                    Code = request.Code,
                    Description = request.Description,
                    CreationTime = DateTime.Now.ToString(),
                    CreatorUserId = userId,
                    IsDeleted = false,
                    Status= request.Status,
                    TeacherId = request.TeacherId
                };

                _dbContext.Course.Add(obj);
                await _dbContext.SaveChangesAsync(cancellationToken);

                var responseModel = new {
                    Name = obj.Name,
                    Id = int.Parse (obj.Id.ToString ()),
                    Code = obj.Code,
                    Description = obj.Description,
                    Image = obj.Image,
                };

                res.data = responseModel;
                res.response_code = 0;
                res.message = "Course Created";
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