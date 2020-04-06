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

namespace Application.Courses.Commands.AddCourse
{
    public class AddCourseCommandHandler: IRequestHandler<AddCourseCommand, ApiResponse>
    {
        private readonly IBridgeDbContext _dbContext;
        private readonly ICurrentUserService _userService;
        private readonly IUserHelper _userHelper;
        public AddCourseCommandHandler(IBridgeDbContext dbContext, ICurrentUserService userService, IUserHelper userHelper)
        {
            _dbContext = dbContext;
            _userService = userService;
            _userHelper = userHelper;
        }

        public async Task<ApiResponse> Handle(AddCourseCommand request, CancellationToken cancellationToken)
        {
            ApiResponse res = new ApiResponse();
            string mediaLink = "";
            try
            {
                if (_userService.RoleList.Contains(Roles.admin.ToString()))
                {
                    string jsonPath = Path.GetFileName(hostingEnvironment.WebRootPath + "/training24-28e994f9833c.json");
                    var credential = GoogleCredential.FromFile(jsonPath);
                    var _storageClient = StorageClient.Create(credential);
                    var userId = await _userHelper.getUserId(_userService.UserId);
                    if (request.file != null)
                    {
                        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };
                        var ext = request.FileName.Substring(request.FileName.LastIndexOf("."));
                        var extension = ext.ToLower();
                        if (AllowedFileExtensions.Contains(extension))
                        {
                            Guid imageGuid = Guid.NewGuid();
                            request.FileName = request.FileName.Split(".")[0] + "_" + imageGuid.ToString() + extension;

                            var imageAcl = PredefinedObjectAcl.PublicRead;
                            var imageObject = await _storageClient.UploadObjectAsync(
                                bucket: "edg-primary-course-image-storage",
                                objectName: request.FileName,
                                contentType: request.file.ContentType,
                                source: request.file.OpenReadStream(),
                                options: new UploadObjectOptions { PredefinedAcl = imageAcl }
                            );
                            mediaLink = imageObject.MediaLink;
                        }
                    }
                    Course obj = new Course {
                        Name = request.name,
                        Code = request.code,
                        Description = request.description,
                        Image = mediaLink,
                        // CreationTime = DateTime.Now.ToString(),
                        // CreatorUserId = userId,
                        istrial = request.istrial,
                        // IsDeleted = false
                    };
                    _dbContext.Course.Add(obj);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    
                    CourseGrade courseGrade = new CourseGrade {
                        CourseId = obj.Id,
                        Gradeid = request.gradeid,
                        //IsDeleted = false,
                        //CreationTime = DateTime.Now.ToString();
                        //CreatorUserId = userId,
                    };
                    _dbContext.CourseGrade.Add(courseGrade);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    Grade newGrade = await _dbContext.Grade.FirstOrDefaultAsync(x=>x.Id == request.gradeid);
                    var responseModel = new {
                        Name = obj.Name,
                        Id = int.Parse(obj.Id.ToString()),
                        Code = obj.Code,
                        Description = obj.Description,
                        Image = obj.Image,
                        gradeid = newGrade.Id,
                        gradename = newGrade.Name,
                        istrial = obj.istrial
                    };

                    res.data = responseModel;
                    res.response_code = 0;
                    res.message = "Course Created";
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