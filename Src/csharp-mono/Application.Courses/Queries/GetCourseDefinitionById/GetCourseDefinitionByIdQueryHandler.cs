using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Courses.Queries.GetCourseDefinition;
using Bridge.Application.Interfaces;
using Bridge.Application.Models;
using Bridge.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Courses.Queries.GetCourseDefinitionById
{
    public class GetCourseDefinitionByIdQueryHandler : IRequestHandler<GetCourseDefinitionByIdQuery, ApiResponse>
    {
        private readonly IBridgeDbContext _dbContext;
        public GetCourseDefinitionByIdQueryHandler(IBridgeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ApiResponse> Handle(GetCourseDefinitionByIdQuery request, CancellationToken cancellationToken)
        {
            ApiResponse res = new ApiResponse();
            try
            {
                CourseDefination ifExist = await _dbContext.CourseDefination.FirstOrDefaultAsync(x => x.Id == request.Id );
                if (ifExist != null)
                {

                    CourseDefinitionVm vmObj = new CourseDefinitionVm()
                    {
                        Id = ifExist.Id,
                        BasePrice = ifExist.BasePrice,
                        CourseId = ifExist.CourseId,
                        CourseName = _dbContext.Course.FirstOrDefault(x => x.Id == ifExist.CourseId ).Name,
                        GradeId = ifExist.GradeId,
                        GradeName = _dbContext.Grade.FirstOrDefault(x => x.Id == ifExist.GradeId).Name,
                        Subject = ifExist.Subject,
                    };

                    if (vmObj != null)
                    {
                        res.data = vmObj;
                        res.response_code = 0;
                        res.message = "CourseDefination Detail";
                        res.status = "Success";
                        res.ReturnCode = 200;
                    }
                };
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