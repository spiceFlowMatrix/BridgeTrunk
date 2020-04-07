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

namespace Application.Courses.Queries.GetPaginatedCourse
{
    public class GetPaginatedCourseQueryHandler: IRequestHandler<GetPaginatedCourseQuery, ApiResponse>
    {
        private readonly IBridgeDbContext _dbContext;
        private readonly ICurrentUserService _userService;
        private readonly IUserHelper _userHelper;
        public GetPaginatedCourseQueryHandler(IBridgeDbContext dbContext, ICurrentUserService userService, IUserHelper userHelper)
        {
            _dbContext = dbContext;
            _userService = userService;
            _userHelper = userHelper;
        }
        public async Task<ApiResponse> Handle(GetPaginatedCourseQuery request, CancellationToken cancellationToken)
        {
            ApiResponse res = new ApiResponse();
            List<PaginatedCourseDTO> responseModel = new List<PaginatedCourseDTO>();
            try
            {
                string Certificate = Path.GetFileName("../../training24-28e994f9833c.json");
                if (_userService.RoleList.Contains(Roles.admin.ToString()))
                {
                    int total = 0;
                    List<Course> courseList = await _dbContext.Course.ToListAsync();
                    List<Grade> gradeList = await _dbContext.Grade.ToListAsync();
                    if (request.pagenumber != 0 && request.perpagerecord != 0)
                    {
                        total = courseList.Count();

                        if (!string.IsNullOrEmpty(request.search))
                        {
                            courseList = courseList.Where(b => b.Code != null && b.Code.ToLower().Contains(request.search.ToLower()) ||
                            b.Name != null && b.Name.ToLower().Contains(request.search.ToLower()) ||
                            b.Id.ToString().ToLower().Contains(request.search.ToLower())).ToList();

                            total = courseList.Count();

                            courseList = courseList.OrderByDescending(b => b.Id).
                                        Skip(request.perpagerecord * (request.pagenumber - 1)).
                                        Take(request.perpagerecord).
                                        ToList();
                        }
                        else
                        {
                            courseList = courseList.OrderByDescending(b => b.Id).
                                        Skip(request.perpagerecord * (request.pagenumber - 1)).
                                        Take(request.perpagerecord).
                                        ToList();
                        }
                    }
                    else 
                    {
                        total = courseList.Count();
                    }

                    foreach (Course course in courseList)
                    {
                        string imageurl = "";
                        if (!string.IsNullOrEmpty(course.Image))
                        {
                            if (course.Image.Contains("t24-primary-image-storage"))
                              imageurl = course.Image;
                            else
                              imageurl = _userHelper.getUrl(course.Image, Certificate);
                        }
                        PaginatedCourseDTO paginatedModel = new PaginatedCourseDTO
                        {
                            Name = course.Name,
                            Id = int.Parse(course.Id.ToString()),
                            Code = course.Code,
                            Description = course.Description,
                            Image = imageurl,
                            istrial = course.istrial
                        };

                        CourseGrade courseGrade = await _dbContext.CourseGrade.FirstOrDefaultAsync(x=>x.CourseId == course.Id);
                        if (courseGrade != null)
                        {
                            Grade grade = gradeList.FirstOrDefault(x=>x.Id == courseGrade.Gradeid);
                            if (grade != null) 
                            {
                                paginatedModel.gradeid = grade.Id;
                                paginatedModel.gradename = grade.Name;
                            }
                        }
                        responseModel.Add(paginatedModel);
                    }

                    res.data = responseModel;
                    res.totalcount = total;
                    res.response_code = 0;
                    res.message = "Course Details";
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