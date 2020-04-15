using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Helpers;
using Application.Interfaces;
using Bridge.Application.Interfaces;
using Bridge.Application.Models;
using Bridge.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Courses.Commands.UpsertCourseDefinition
{
    public class UpsertCourseDefinationCommandHandler : IRequestHandler<UpsertCourseDefinationCommand, ApiResponse>
    {
        private readonly IBridgeDbContext _dbContext;
        private readonly ICurrentUserService _userService;
        private readonly IUserHelper _userHelper;
        public UpsertCourseDefinationCommandHandler(IBridgeDbContext dbContext, ICurrentUserService userService, IUserHelper userHelper)
        {
            _dbContext = dbContext;
            _userService = userService;
            _userHelper = userHelper;
        }
        public async Task<ApiResponse> Handle(UpsertCourseDefinationCommand request, CancellationToken cancellationToken)
        {
            ApiResponse res = new ApiResponse();
            try
            {
                // if (_userService.RoleList.Contains(Roles.admin.ToString()))
                // {
                var userId = _userService.UserId;

                if (request.Id == 0)
                {
                    CourseDefination ifExistCourse = await _dbContext.CourseDefination.FirstOrDefaultAsync(b => b.Subject == request.Subject);

                    if (ifExistCourse != null)
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
                            CreationTime = DateTime.UtcNow.ToString(),
                            CreatorUserId = userId,
                            Subject = request.Subject,
                            BasePrice = request.BasePrice,
                            GradeId = request.GradeId,
                            CourseId = request.CourseId,
                        };
                        await _dbContext.CourseDefination.AddAsync(obj);
                        await _dbContext.SaveChangesAsync(cancellationToken);
                        UpsertCourseDefinitionVm vmObj = new UpsertCourseDefinitionVm();
                        if (obj != null)
                        {
                            vmObj = new UpsertCourseDefinitionVm()
                            {
                                Id = obj.Id,
                                BasePrice = obj.BasePrice,
                                CourseId = obj.CourseId,
                                CourseName = _dbContext.Course.FirstOrDefault(x => x.Id == obj.CourseId).Name,
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
                    var ifExistCourseSubject = _dbContext.CourseDefination.Where(b => b.Id == request.Id &&
                                                                                           b.IsDeleted == false)
                                                                                 .AsQueryable();


                    if (ifExistCourseSubject != null)
                    {
                        var ifEXist = ifExistCourseSubject.Where(b => b.Id == request.Id && b.Subject.ToLower().ToString() == request.Subject.ToLower().ToString()).FirstOrDefault();
                        if (ifEXist != null)
                        {
                            res.response_code = 1;
                            res.message = "Duplicate entry.";
                            res.status = "Unsuccess";
                            res.ReturnCode = 422;
                        }
                        else
                        {
                            CourseDefination ifEXistSubject = ifExistCourseSubject.Where(x => x.Id == request.Id).FirstOrDefault();

                            ifEXistSubject.BasePrice = request.BasePrice;
                            ifEXistSubject.CourseId = request.CourseId;
                            ifEXistSubject.GradeId = request.GradeId;
                            ifEXistSubject.Subject = request.Subject;
                            ifEXistSubject.LastModificationTime = DateTime.UtcNow.ToString();
                            await _dbContext.SaveChangesAsync(cancellationToken);

                            UpsertCourseDefinitionVm vmObj = new UpsertCourseDefinitionVm();

                            vmObj = new UpsertCourseDefinitionVm()
                            {
                                Id = ifEXistSubject.Id,
                                BasePrice = ifEXistSubject.BasePrice,
                                CourseId = ifEXistSubject.CourseId,
                                CourseName = _dbContext.Course.FirstOrDefault(x => x.Id == ifEXistSubject.CourseId).Name,
                                GradeId = ifEXistSubject.GradeId,
                                GradeName = _dbContext.Grade.FirstOrDefault(x => x.Id == ifEXistSubject.GradeId).Name,
                                Subject = ifEXistSubject.Subject,
                            };

                            res.data = vmObj;
                            res.response_code = 0;
                            res.message = "CourseDefination Updated";
                            res.status = "Success";
                            res.ReturnCode = 200;
                        }
                    }
                }
                //}
                // else
                // {
                //     res.response_code = 1;
                //     res.message = "You are not authorized.";
                //     res.status = "Unsuccess";
                //     res.ReturnCode = 401;
                // }
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