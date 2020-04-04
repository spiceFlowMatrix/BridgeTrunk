using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bridge.Application.Models;
using Bridge.Domain.Entities;
using Bridge.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Courses.Commands.UpsertCourseDefinition
{
    public class UpsertCourseDefinationCommandHandler : IRequestHandler<UpsertCourseDefinationCommand, ApiResponse>
    {
        private readonly BridgeDbContext _dbContext;
        public UpsertCourseDefinationCommandHandler(BridgeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ApiResponse> Handle(UpsertCourseDefinationCommand request, CancellationToken cancellationToken)
        {
            ApiResponse res = new ApiResponse();
            try
            {
                if (request.Id == 0)
                {
                    CourseDefination coourse = _dbContext.CourseDefination.FirstOrDefault(b => b.Subject == request.Subject);

                    if (coourse != null)
                    {
                        res.response_code = 1;
                        res.message = "Duplicate entry.";
                        res.status = "Unsuccess";
                        res.ReturnCode = 422;
                    }
                    else
                    {
                        CourseDefination obj = new CourseDefination()
                        {
                            CreatedOn = DateTime.UtcNow,
                            CreatedBy = 0,
                            IsDeleted = false,
                            //Subject = request.Subject
                        };
                        await _dbContext.AddAsync(obj);
                        await _dbContext.SaveChangesAsync();
                        UpsertCourseDefinitionVm vmObj = new UpsertCourseDefinitionVm();
                        if (obj != null)
                        {
                            vmObj = new UpsertCourseDefinitionVm()
                            {
                                Id = obj.Id,
                                BasePrice = obj.BasePrice,
                                CourseId = obj.CourseId,
                                CourseName = _dbContext.Course.FirstOrDefault(x => x.Id == obj.Id && x.IsDeleted == false).Name,
                                GradeId = obj.GradeId,
                                GradeName = _dbContext.Grade.FirstOrDefault(x => x.Id == obj.GradeId).Name,
                                Subject = obj.Subject,
                            };
                        }

                        res.data = vmObj;
                        res.response_code = 0;
                        res.message = "CourseDefination Created";
                        res.status = "Success";
                        res.ReturnCode = 200;

                    }
                }

                else
                {
                    CourseDefination courseDefination = _dbContext.CourseDefination.Where(b => b.Subject.ToLower().ToString() == request.Subject.ToLower().ToString() && b.Id == request.Id).SingleOrDefault();

                    if (courseDefination != null)
                    {
                        res.response_code = 1;
                        res.message = "Duplicate entry.";
                        res.status = "Unsuccess";
                        res.ReturnCode = 422;
                    }
                    else
                    {
                        courseDefination.BasePrice = request.BasePrice;
                        courseDefination.CourseId = request.CourseId;
                        courseDefination.GradeId = request.GradeId;
                        courseDefination.Subject = request.Subject;
                        courseDefination.LastModifiedOn = DateTime.UtcNow;
                        courseDefination.LastModifiedBy = 0;
                    }
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