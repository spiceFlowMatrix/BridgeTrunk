using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bridge.Application.Interfaces;
using Bridge.Application.Models;
using Bridge.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Courses.Queries.GetCourseDefinition
{
    public class GetCourseDefinitionQueryHandler : IRequestHandler<GetCourseDefinitionQuery, ApiResponse>
    {
        private readonly IBridgeDbContext _dbContext;
        public GetCourseDefinitionQueryHandler(IBridgeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ApiResponse> Handle(GetCourseDefinitionQuery request, CancellationToken cancellationToken)
        {
            ApiResponse res = new ApiResponse();
            try
            {
                List<CourseDefination> CourseDefinationList = new List<CourseDefination>();
                CourseDefinationList = await _dbContext.CourseDefination.OrderByDescending(b => b.Id).ToListAsync(); ;
                if (CourseDefinationList.Any())
                {

                    if (request.Pagenumber != 0 && request.Perpagerecord != 0)
                    {

                        CourseDefinationList = CourseDefinationList.OrderByDescending(b => b.Id).
                                Skip(request.Perpagerecord * (request.Pagenumber - 1)).
                                Take(request.Perpagerecord).
                                ToList();

                        if (!string.IsNullOrEmpty(request.Search))
                            CourseDefinationList = CourseDefinationList.OrderByDescending(b => b.Id).Where(
                                                               b => b.Id.ToString().Any(k => b.Id.ToString().Contains(request.Search))
                                                            || b.Subject.ToString().ToLower().Any(k => b.Subject.ToLower().ToString().Contains(request.Search.ToLower().ToString()))
                                                            || b.BasePrice.ToString().ToLower().Any(k => b.BasePrice.ToString().Contains(request.Search))
                                                            ).ToList();

                    }

                    List<CourseDefinitionVm> courseDefinationList = new List<CourseDefinitionVm>();
                    foreach (var courseDefination in CourseDefinationList)
                    {
                        CourseDefinitionVm obj = new CourseDefinitionVm()
                        {
                            Id = courseDefination.Id,
                            BasePrice = courseDefination.BasePrice,
                            CourseId = courseDefination.CourseId,
                            CourseName = _dbContext.Course.FirstOrDefault(x => x.Id == courseDefination.CourseId ).Name,
                            GradeId = courseDefination.GradeId,
                            GradeName = _dbContext.Grade.FirstOrDefault(x => x.Id == courseDefination.GradeId).Name,
                            Subject = courseDefination.Subject,
                        };
                        courseDefinationList.Add(obj);

                    }
                    res.totalcount = CourseDefinationList.Count();
                    res.data = courseDefinationList;
                    res.response_code = 0;
                    res.message = "CourseDefination Details";
                    res.status = "Success";
                    res.ReturnCode = 200;
                }
            }
            catch (Exception ex)
            {
                res.ReturnCode = 500;
                res.response_code = 2;
                res.message = ex.Message;
                res.status = "Failure";
            }
            return res;
        }
    }
}