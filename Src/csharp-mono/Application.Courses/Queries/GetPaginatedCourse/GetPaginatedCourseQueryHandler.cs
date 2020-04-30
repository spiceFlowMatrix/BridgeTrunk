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

namespace Application.Courses.Queries.GetPaginatedCourse
{
    // Updated by Arjun Singh 29/04/2020
    public class GetPaginatedCourseQueryHandler : IRequestHandler<GetPaginatedCourseQuery, ApiResponse>
    {
        private readonly IBridgeDbContext _dbContext;
        private readonly IUserHelper _userHelper;
        public GetPaginatedCourseQueryHandler(IBridgeDbContext dbContext, IUserHelper userHelper)
        {
            _dbContext = dbContext;
            _userHelper = userHelper;
        }
        public async Task<ApiResponse> Handle(GetPaginatedCourseQuery request, CancellationToken cancellationToken)
        {
            ApiResponse res = new ApiResponse();
            string certificate = Path.GetFileName(Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS"));
            try
            {
                var courseQuery = _dbContext.Course.Where(x => x.IsDeleted == false);

                if (!string.IsNullOrEmpty(request.search))
                {
                    var courseSearchQuery = courseQuery.Where(x =>
                           (x.Code.ToLower().Contains(request.search.ToLower()) ||
                               x.Name.ToLower().Contains(request.search.ToLower()) ||
                               x.Id.ToString().ToLower().Contains(request.search.ToLower()))
                        ).Select(x => new PaginatedCourseDTO
                        {
                            Name = x.Name,
                            Id = int.Parse(x.Id.ToString()),
                            Code = x.Code,
                            Description = x.Description,
                            Image = x.Image.Contains("t24-primary-image-storage") ? x.Image : _userHelper.getUrl(x.Image, certificate),
                        }).AsQueryable();

                        res.totalcount = await courseSearchQuery.CountAsync();
                        res.data = await courseSearchQuery.Skip(request.perPageRecord * request.pageNumber)
                        .Take(request.perPageRecord)
                        .OrderByDescending(x => x.Code)
                        .ToListAsync();
                }
                else
                {
                    var courseResult = await courseQuery.Where(x => x.IsDeleted == false).Select(x => new
                    {
                        Name = x.Name,
                        Id = int.Parse(x.Id.ToString()),
                        Code = x.Code,
                        Description = x.Description,
                        Image = x.Image.Contains("t24-primary-image-storage") ? x.Image : _userHelper.getUrl(x.Image, certificate),
                    }).Skip(request.perPageRecord * request.pageNumber)
                    .Take(request.perPageRecord)
                    .ToListAsync();

                    res.totalcount = await courseQuery.CountAsync();
                    res.data = courseResult.OrderByDescending(x => x.Code);
                }

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