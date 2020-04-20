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

namespace Application.Courses.Queries.GetCourseList
{
    public class GetCourseListQueryHandler: IRequestHandler<GetCourseListQuery, ApiResponse>
    {
        private readonly IBridgeDbContext _dbContext;
        public GetCourseListQueryHandler(IBridgeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ApiResponse> Handle(GetCourseListQuery request, CancellationToken cancellationToken)
        {
            ApiResponse res = new ApiResponse();
            try
            {
                string Certificate = Path.GetFileName(Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS"));
                int total = 0;
                var courseList = await _dbContext.Course.Where(x=>x.IsDeleted == false).Select(s => new
                {
                    s.Id,
                    s.Name,
                    s.Code
                }).ToListAsync();
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

                res.data = courseList;
                res.totalcount = total;
                res.response_code = 0;
                res.message = "Course Details";
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