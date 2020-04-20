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
            string mediaLink = "";
            GoogleCredential cred;
            try 
            {
                using (var stream = new FileStream (Environment.GetEnvironmentVariable ("GOOGLE_APPLICATION_CREDENTIALS"), FileMode.Open, FileAccess.Read)) {
                    cred = GoogleCredential.FromStream (stream);
                }
                // var credential = GoogleCredential.FromFile(Directory.GetCurrentDirectory() + "../../training24-28e994f9833c.json");
                var _storageClient = StorageClient.Create (cred);
                string userId = _userService.UserId;
                if (request.file != null) {
                    IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };
                    var ext = request.FileName.Substring (request.FileName.LastIndexOf ("."));
                    var extension = ext.ToLower ();
                    if (AllowedFileExtensions.Contains (extension)) {
                        Guid imageGuid = Guid.NewGuid ();
                        request.FileName = request.FileName.Split (".") [0] + "_" + imageGuid.ToString () + extension;

                        var imageAcl = PredefinedObjectAcl.PublicRead;
                        var imageObject = await _storageClient.UploadObjectAsync (
                            bucket: "edg-primary-course-image-storage",
                            objectName : request.FileName,
                            contentType : request.file.ContentType,
                            source : request.file.OpenReadStream (),
                            options : new UploadObjectOptions { PredefinedAcl = imageAcl }
                        );
                        mediaLink = imageObject.MediaLink;
                    }
                }
                Course obj = new Course {
                    Name = request.name,
                    Code = request.code,
                    Description = request.description,
                    Image = mediaLink,
                    CreationTime = DateTime.Now.ToString (),
                    CreatorUserId = userId,
                    istrial = request.istrial,
                    IsDeleted = false
                };
                _dbContext.Course.Add (obj);
                await _dbContext.SaveChangesAsync (cancellationToken);

                CourseGrade courseGrade = new CourseGrade {
                    CourseId = obj.Id,
                    Gradeid = request.gradeid,
                    IsDeleted = false,
                    CreationTime = DateTime.Now.ToString (),
                    CreatorUserId = userId
                };
                _dbContext.CourseGrade.Add (courseGrade);
                await _dbContext.SaveChangesAsync (cancellationToken);
                Grade newGrade = await _dbContext.Grade.FirstOrDefaultAsync (x => x.Id == request.gradeid && x.IsDeleted == false);
                var responseModel = new {
                    Name = obj.Name,
                    Id = int.Parse (obj.Id.ToString ()),
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