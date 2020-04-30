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

namespace Application.Courses.Queries.GetCourse
{
    public class GetCourseQueryHandler: IRequestHandler<GetCourseQuery, ApiResponse>
    {
        private readonly IBridgeDbContext _dbContext;
        private readonly IUserHelper _userHelper;
        public GetCourseQueryHandler(IBridgeDbContext dbContext, IUserHelper userHelper)
        {
            _dbContext = dbContext;
            _userHelper = userHelper;
        }
        public async Task<ApiResponse> Handle(GetCourseQuery request, CancellationToken cancellationToken)
        {
            ApiResponse res = new ApiResponse();
            try
            {
                string Certificate = Path.GetFileName(Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS"));
                CourseDTO responseCourseModel = null;
                Course course = await _dbContext.Course
                                                .Include(x=> x.Teacher)
                                                .FirstOrDefaultAsync(x=>x.Id == request.id && x.IsDeleted == false);
                string imageurl = "";
                if(course != null)
                {
                    if (!string.IsNullOrEmpty(course.Image))
                    {
                        if (course.Image.Contains("t24-primary-image-storage"))
                            imageurl = course.Image;
                        else
                            imageurl = _userHelper.getUrl(course.Image, Certificate);
                    }

                    responseCourseModel = new CourseDTO
                    {
                        Name = course.Name,
                        Id = int.Parse(course.Id.ToString()),
                        Code = course.Code,
                        Culture= course.Culture,
                        Status= course.Status,
                        TeacherId= course.TeacherId,
                        Description = course.Description,
                        Image = imageurl,
                        TeacherName = course.Teacher != null ? course.Teacher.FullName: null,
                        StatusName= ((CourseStatus)course.Status).ToString(),
                        CultureName = ((Culture)course.Culture).ToString()
                    };

                    // CourseGrade courseGrade = await _dbContext.CourseGrade.FirstOrDefaultAsync(x=>x.CourseId == course.Id && x.IsDeleted == false);
                    // if (courseGrade != null)
                    // {
                    //     Grade grade = await _dbContext.Grade.FirstOrDefaultAsync(x=>x.Id == courseGrade.Gradeid && x.IsDeleted == false);
                    //     if (grade != null) 
                    //     {
                    //         responseCourseModel.gradeid = grade.Id;
                    //         responseCourseModel.gradename = grade.Name;
                    //     }
                    // }
                }

                res.data = responseCourseModel;
                res.response_code = 0;
                res.message = "Course Detail";
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