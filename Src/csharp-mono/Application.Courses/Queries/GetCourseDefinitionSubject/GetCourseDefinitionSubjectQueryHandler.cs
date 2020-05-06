using System.Threading;
using System.Threading.Tasks;
using Bridge.Application.Models;
using Bridge.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using Bridge.Domain.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Application.Courses.Queries.GetCourseDefinitionSubject
{
    public class GetCourseDefinitionSubjectQueryHandler : IRequestHandler<GetCourseDefinitionSubjectQuery, ApiResponse>
    {
        private readonly IBridgeDbContext _dbContext;
        public GetCourseDefinitionSubjectQueryHandler(IBridgeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ApiResponse> Handle(GetCourseDefinitionSubjectQuery request, CancellationToken cancellationToken)
        {
            ApiResponse res = new ApiResponse();
            try
            {
                List<CourseDefination> courseDefinationList = new List<CourseDefination>();
                List<CourseDefinationSubjectVm> vmObj = new List<CourseDefinationSubjectVm>();
                if (!string.IsNullOrEmpty(request.Search))
                {
                    courseDefinationList = await _dbContext.CourseDefination.Where(b =>  b.Subject.ToLower().Contains(request.Search.ToLower().ToString())).ToListAsync();
                    if (courseDefinationList.Any())
                    {
                        foreach (var item in courseDefinationList)
                        {
                            CourseDefinationSubjectVm subjectObj = new CourseDefinationSubjectVm()
                            {
                                Id = item.Id,
                                BasePrice = item.BasePrice,
                                CourseId = item.CourseId,
                                CourseName = _dbContext.Course.FirstOrDefault(x => x.Id == item.CourseId).Name,
                                GradeId = item.GradeId,
                                GradeName = _dbContext.Grade.FirstOrDefault(x => x.Id == item.GradeId).Name,
                                Subject = item.Subject,
                            };
                            vmObj.Add(subjectObj);
                        }
                        res.data = vmObj;
                        res.response_code = 0;
                        res.message = "Subject list details";
                        res.status = "Success";
                        res.ReturnCode = StatusCodes.Status200OK;
                    }
                }

            }
            catch (Exception ex)
            {
                res.ReturnCode = StatusCodes.Status500InternalServerError;
                res.response_code = 2;
                res.message = ex.Message;
                res.status = "Failure";
            }
            return res;
        }
    }
}