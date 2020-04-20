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
    public class UpdateCourseCommandHandler: IRequestHandler<UpdateCourseCommand, ApiResponse>
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
            string mediaLink = "";
            GoogleCredential credential;
            try
            {
                // string jsonPath = Path.GetFileName(hostingEnvironment.WebRootPath + "/training24-28e994f9833c.json");
                using (var stream = new FileStream (Environment.GetEnvironmentVariable ("GOOGLE_APPLICATION_CREDENTIALS"), FileMode.Open, FileAccess.Read)) {
                    credential = GoogleCredential.FromStream (stream);
                }
                var _storageClient = StorageClient.Create(credential);
                var userId = _userService.UserId;
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
                Course obj = await _dbContext.Course.FirstOrDefaultAsync(x=> x.Id == request.id && x.IsDeleted == false);
                if (obj != null)
                {
                    obj.Name = request.name;
                    obj.Code = request.code;
                    obj.Description = request.description;            
                    obj.PassMark = request.passmark;
                    obj.istrial = request.istrial;
                    obj.LastModificationTime = DateTime.Now.ToString();
                    obj.LastModifierUserId = userId;
                    if (!string.IsNullOrEmpty(mediaLink))
                        obj.Image = mediaLink;

                    await _dbContext.SaveChangesAsync(cancellationToken);
                }

                CourseGrade courseGradeExits = await _dbContext.CourseGrade.Where(b => b.CourseId == request.id && b.IsDeleted == false).SingleOrDefaultAsync();
                if (courseGradeExits != null)
                {
                    if(courseGradeExits.Gradeid != request.gradeid)
                    {
                        courseGradeExits.Id = courseGradeExits.Id;
                        courseGradeExits.CourseId = request.id;
                        courseGradeExits.Gradeid = request.gradeid;
                        courseGradeExits.IsDeleted = false;
                        courseGradeExits.LastModificationTime = DateTime.Now.ToString();
                        courseGradeExits.LastModifierUserId = userId;
                        await _dbContext.SaveChangesAsync(cancellationToken);
                    }
                }

                // CourseBusiness.SendNotificationOnCourseUpdate(newCourse, jsonPath, int.Parse(tc.Id));
                Grade newGrade = await _dbContext.Grade.FirstOrDefaultAsync(x=>x.Id == request.gradeid && x.IsDeleted == false);
                var responseModel = new {
                    Name = obj.Name,
                    Id = int.Parse(obj.Id.ToString()),
                    Code = obj.Code,
                    Description = obj.Description,
                    Image = obj.Image,
                    gradeid = newGrade.Id,
                    gradename = newGrade.Name
                };

                res.data = responseModel;
                res.response_code = 0;
                res.message = "Course updated";
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