using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Helpers;
using Application.Interfaces;
using Bridge.Application.Interfaces;
using Bridge.Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Courses.Commands.UpdateCourseGrade {
    public class UpdateCourseGradeCommandHandler : IRequestHandler<UpdateCourseGradeCommand, ApiResponse> {
        private readonly IBridgeDbContext _dbContext;
        private readonly ICurrentUserService _userService;
        public UpdateCourseGradeCommandHandler (IBridgeDbContext dbContext, ICurrentUserService userService) {
            _dbContext = dbContext;
            _userService = userService;
        }

        public async Task<ApiResponse> Handle (UpdateCourseGradeCommand request, CancellationToken cancellationToken) {
            ApiResponse res = new ApiResponse ();
            try {

                var userId = _userService.UserId;
                // if (_userService.RoleList.Contains (Roles.admin.ToString ())) {

                    var isExist = await _dbContext.CourseGrade.Where (x => x.Id == request.id &&
                        x.IsDeleted == false
                    ).FirstOrDefaultAsync ();
                    if (isExist != null) {
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
                        res.message = "CourseGrade Updated";
                        res.status = "Success";
                        res.ReturnCode = 200;
                    } else {
                        res.response_code = 1;
                        res.message = "Already Exist";
                        res.status = "Unsuccess";
                        res.ReturnCode = 422;
                    }
                // } else {
                //     res.response_code = 1;
                //     res.message = "You are not authorized";
                //     res.status = "Unsuccess";
                //     res.ReturnCode = 401;
                // }
            } catch (Exception ex) {
                res.ReturnCode = 500;
                res.response_code = 2;
                res.message = ex.Message;
                res.status = "Failure";
            }
            return res;
        }
    }
}