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

namespace Application.Courses.Queries.GetCourseGrade {
    public class GetCourseGradeQueryHandler : IRequestHandler<GetCourseGradeQuery, ApiResponse> {
        private readonly IBridgeDbContext _dbContext;
        private readonly ICurrentUserService _userService;        
        public GetCourseGradeQueryHandler (IBridgeDbContext dbContext, ICurrentUserService userService) {
            _dbContext = dbContext;
            _userService = userService;
        }

        public async Task<ApiResponse> Handle (GetCourseGradeQuery request, CancellationToken cancellationToken) {
            ApiResponse res = new ApiResponse ();
            try {
                //if (_userService.RoleList.Contains (Roles.admin.ToString ())) {
                    CourseGradeVm objVm = await _dbContext.CourseGrade.Where (x => x.Id == request.id
                     && x.IsDeleted==false
                    ).Select (y => new CourseGradeVm {
                        id = y.Id,
                            courseid = y.CourseId,
                            gradeid = y.Gradeid
                    }).FirstOrDefaultAsync ();

                    if (objVm != null) {
                        res.data = objVm;
                        res.response_code = 0;
                        res.message = "CourseGrade Detail";
                        res.status = "Success";
                        res.ReturnCode = 200;
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