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

namespace Application.Courses.Commands.AddCourseGrade {
    public class AddCourseGradeCommandHandler : IRequestHandler<AddCourseGradeCommand, ApiResponse> {
        private readonly IBridgeDbContext _dbContext;
        private readonly ICurrentUserService _userService;
        private readonly IUserHelper _userHelper;
        public AddCourseGradeCommandHandler (IBridgeDbContext dbContext, ICurrentUserService userService, IUserHelper userHelper) {
            _dbContext = dbContext;
            _userService = userService;
            _userHelper = userHelper;
        }

        public async Task<ApiResponse> Handle (AddCourseGradeCommand request, CancellationToken cancellationToken) {
            ApiResponse res = new ApiResponse ();
            try {
                var userId = await _userHelper.getUserId (_userService.UserId.ToString());
                //var id= int.Parse(userId);
                if (_userService.RoleList.Contains (Roles.admin.ToString ())) {

                    var isExist = await _dbContext.CourseGrade.Where (x => x.CourseId == request.courseid
                        //  && x.IsDeleted==false
                    ).FirstOrDefaultAsync ();
                    if (isExist == null) {
                        CourseGrade obj = new CourseGrade () {
                        CourseId = request.courseid,
                        Gradeid = request.gradeid,
                        // IsDeleted = false,
                        CreationTime = DateTime.UtcNow.ToString (),
                        CreatorUserId = userId
                        };
                        await _dbContext.CourseGrade.AddAsync (obj);
                        await _dbContext.SaveChangesAsync (cancellationToken);
                        CourseGradeVm model = new CourseGradeVm () {
                            id = obj.Id,
                            courseid = obj.CourseId,
                            gradeid = obj.Gradeid
                        };
                        res.data = model;
                        res.response_code = 0;
                        res.message = "CourseGrade Created";
                        res.status = "Success";
                        res.ReturnCode = 200;
                    } else {
                        if (isExist.Gradeid != request.gradeid) {
                            isExist.CourseId = request.courseid;
                            isExist.Gradeid = request.gradeid;
                            isExist.LastModificationTime = DateTime.UtcNow.ToString ();
                            isExist.LastModifierUserId = userId;
                            await _dbContext.SaveChangesAsync (cancellationToken);
                            CourseGradeVm model = new CourseGradeVm () {
                                id = isExist.Id,
                                courseid = isExist.CourseId,
                                gradeid = isExist.Gradeid
                            };
                            res.data = model;
                            res.response_code = 0;
                            res.message = "CourseGrade Created";
                            res.status = "Success";
                            res.ReturnCode = 200;
                        } else {
                            res.response_code = 1;
                            res.message = "Allready assigned";
                            res.status = "Unsuccess";
                            res.ReturnCode = 422;
                        }
                    }
                } else {
                    res.response_code = 1;
                    res.message = "You are not authorized";
                    res.status = "Unsuccess";
                    res.ReturnCode = 401;
                }

            } catch (Exception ex) {
                res.ReturnCode = 500;
                res.response_code = 1;
                res.message = ex.Message;
                res.status = "Failure";
            }
            return res;
        }
    }
}