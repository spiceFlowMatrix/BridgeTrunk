using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bridge.Application.Interfaces;
using Bridge.Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Courses.Queries.GetCourseGrade
{
    public class GetCourseGradeQueryHandler: IRequestHandler<GetCourseGradeQuery, ApiResponse>
    {
        private readonly IBridgeDbContext _dbContext;
        public GetCourseGradeQueryHandler (IBridgeDbContext dbContext) {
            _dbContext = dbContext;
        }
  
        public async Task<ApiResponse> Handle(GetCourseGradeQuery request, CancellationToken cancellationToken)
        {
            ApiResponse res = new ApiResponse();
            try {
                   CourseGradeVm objVm= await _dbContext.CourseGrade.Where(x=>x.Id==request.id && x.IsDeleted==false).Select(y=>new CourseGradeVm {
                       id = y.Id,
                       courseid = y.CourseId,
                       gradeid = y.Gradeid
                   }).FirstOrDefaultAsync();
                    
                    if(objVm!=null)
                    {
                        res.data = objVm;
                        res.response_code = 0;
                        res.message = "CourseGrade Detail";
                        res.status = "Success";
                        res.ReturnCode = 200;
                    }
             } 
            catch(Exception ex){
                res.ReturnCode = 500;
                res.response_code = 2;
                res.message = ex.Message;
                res.status = "Failure";
            }
            return res;
        }
    }
}