using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace Application.Courses.Queries.GetPaginatedCourse {
    // Updated by Arjun Singh 29/04/2020
    public class GetPaginatedCourseQueryHandler : IRequestHandler<GetPaginatedCourseQuery, ApiResponse> {
        private readonly IBridgeDbContext _dbContext;
        private readonly IUserHelper _userHelper;
        public GetPaginatedCourseQueryHandler (IBridgeDbContext dbContext, IUserHelper userHelper) {
            _dbContext = dbContext;
            _userHelper = userHelper;
        }
        public async Task<ApiResponse> Handle (GetPaginatedCourseQuery request, CancellationToken cancellationToken) {
            ApiResponse res = new ApiResponse ();
            string certificate = Path.GetFileName (Environment.GetEnvironmentVariable ("GOOGLE_APPLICATION_CREDENTIALS"));
            try {
                if (request.search != "") {
                    var courseList = await _dbContext.Course.Where (x => x.IsDeleted == false &&
                            (x.Code.ToLower ().Contains (request.search.ToLower ()) ||
                                x.Name.ToLower ().Contains (request.search.ToLower ()) ||
                                x.Id.ToString ().ToLower ().Contains (request.search.ToLower ()))
                        ).Select (x => new PaginatedCourseDTO {
                            Name = x.Name,
                                Id = int.Parse (x.Id.ToString ()),
                                Code = x.Code,
                                Description = x.Description,
                                Image = x.Image.Contains ("t24-primary-image-storage") ? x.Image : _userHelper.getUrl (x.Image, certificate),
                                istrial = x.istrial
                        }).AsQueryable ()
                        .Skip (request.perPageRecord * request.pageNumber)
                        .Take (request.perPageRecord)
                        .ToListAsync ();
                    res.totalcount = courseList.Count ();
                    res.data = courseList.OrderByDescending (x => x.Code);
                } else {
                    var courseList = await _dbContext.Course.Where (x => x.IsDeleted == false).Select (x => new {
                            Name = x.Name,
                                Id = int.Parse (x.Id.ToString ()),
                                Code = x.Code,
                                Description = x.Description,
                                Image = x.Image.Contains ("t24-primary-image-storage") ? x.Image : _userHelper.getUrl (x.Image, certificate),
                                istrial = x.istrial
                        }).AsQueryable ()
                        .Skip (request.perPageRecord * request.pageNumber)
                        .Take (request.perPageRecord)
                        .ToListAsync ();
                    res.totalcount = courseList.Count;
                    res.data = courseList.OrderByDescending (x => x.Code);
                }
                // string Certificate = Path.GetFileName(Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS"));
                // int total = 0;
                // List<Course> courseList = await _dbContext.Course.Where(x=>x.IsDeleted == false).ToListAsync();
                // List<Grade> gradeList = await _dbContext.Grade.Where(x=>x.IsDeleted == false).ToListAsync();
                // if (request.pagenumber != 0 && request.perpagerecord != 0)
                // {
                //     total = courseList.Count();

                //     if (!string.IsNullOrEmpty(request.search))
                //     {
                //         courseList = courseList.Where(b => b.Code != null && b.Code.ToLower().Contains(request.search.ToLower()) ||
                //         b.Name != null && b.Name.ToLower().Contains(request.search.ToLower()) ||
                //         b.Id.ToString().ToLower().Contains(request.search.ToLower())).ToList();

                //         total = courseList.Count();

                //         courseList = courseList.OrderByDescending(b => b.Id).
                //                     Skip(request.perpagerecord * (request.pagenumber - 1)).
                //                     Take(request.perpagerecord).
                //                     ToList();
                //     }
                //     else
                //     {
                //         courseList = courseList.OrderByDescending(b => b.Id).
                //                     Skip(request.perpagerecord * (request.pagenumber - 1)).
                //                     Take(request.perpagerecord).
                //                     ToList();
                //     }
                // }
                // else 
                // {
                //     total = courseList.Count();
                // }

                // foreach (Course course in courseList)
                // {
                //     string imageurl = "";
                //     if (!string.IsNullOrEmpty(course.Image))
                //     {
                //         if (course.Image.Contains("t24-primary-image-storage"))
                //             imageurl = course.Image;
                //         else
                //             imageurl = _userHelper.getUrl(course.Image, Certificate);
                //     }
                //     PaginatedCourseDTO paginatedModel = new PaginatedCourseDTO
                //     {
                //         Name = course.Name,
                //         Id = int.Parse(course.Id.ToString()),
                //         Code = course.Code,
                //         Description = course.Description,
                //         Image = imageurl,
                //         istrial = course.istrial
                //     };

                //     CourseGrade courseGrade = await _dbContext.CourseGrade.FirstOrDefaultAsync(x=>x.CourseId == course.Id && x.IsDeleted == false);
                //     if (courseGrade != null)
                //     {
                //         Grade grade = gradeList.FirstOrDefault(x=>x.Id == courseGrade.Gradeid);
                //         if (grade != null) 
                //         {
                //             paginatedModel.gradeid = grade.Id;
                //             paginatedModel.gradename = grade.Name;
                //         }
                //     }
                //     responseModel.Add(paginatedModel);
                // }

                //res.data = responseModel;
                //res.totalcount = total;
                res.response_code = 0;
                res.message = "Course Details";
                res.status = "Success";
                res.ReturnCode = 200;
            } catch (Exception ex) {
                res.response_code = 2;
                res.message = ex.Message;
                res.status = "Failure";
                res.ReturnCode = 500;
            }
            return res;
        }
    }
}