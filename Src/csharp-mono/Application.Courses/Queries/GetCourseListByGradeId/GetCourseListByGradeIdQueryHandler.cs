using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bridge.Application.Interfaces;
using Bridge.Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Courses.Queries.GetCourseListByGradeId
{
    public class GetCourseListByGradeIdQueryHandler : IRequestHandler<GetCourseListByGradeIdQuery, ApiResponse> {
        private readonly IBridgeDbContext _dbContext;
        public GetCourseListByGradeIdQueryHandler (IBridgeDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<ApiResponse> Handle (GetCourseListByGradeIdQuery request, CancellationToken cancellationToken) {
            ApiResponse res = new ApiResponse ();
            try {                                
               var CourseGradeList = await _dbContext.CourseGrade.Where(x=>x.Gradeid == request.Id
                  && x.IsDeleted == false
                ).ToListAsync();
               if(request.PerPageRecord != 0 && request.PageNumber != 0)
               {
                CourseGradeList = CourseGradeList.OrderByDescending(b => b.CreationTime).
                        Skip(request.PerPageRecord * (request.PageNumber - 1)).
                        Take(request.PerPageRecord).
                        ToList();
               }
                List<CourseListByGradeIdVm> CourseList = new List<CourseListByGradeIdVm>();
                foreach (var item in CourseGradeList)
                {
                    CourseListByGradeIdVm CourseModel = new CourseListByGradeIdVm();
                    var course = await _dbContext.Course.FirstOrDefaultAsync(x=>x.Id==item.CourseId && x.IsDeleted==false);
                    CourseModel.id= item.Id;
                    CourseModel.gradeid = item.Gradeid;
                    CourseModel.courseid = item.CourseId;
                    CourseModel.name = course.Name;
                    CourseModel.code = course.Code;
                    CourseList.Add(CourseModel);
                }
                res.totalcount = CourseGradeList.Count();
                res.data = CourseList;
                res.response_code = 0;
                res.message = "Courses by GradeId";
                res.status = "Success";
                res.ReturnCode = 200;
                
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