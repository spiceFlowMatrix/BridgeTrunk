using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bridge.Application.Interfaces;
using Bridge.Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Courses.Commands.DeleteCourseGrade
{
    public class DeleteCourseGradeCommandHandler : IRequestHandler<DeleteCourseGradeCommand, ApiResponse>
    {
        private readonly IBridgeDbContext _dbContext;
        public DeleteCourseGradeCommandHandler (IBridgeDbContext dbContext) {
            _dbContext = dbContext;
        }
  
        public async Task<ApiResponse> Handle(DeleteCourseGradeCommand request, CancellationToken cancellationToken)
        {
            ApiResponse res = new ApiResponse();
            try {
                    var isExist= await _dbContext.CourseGrade.Where(x=>x.Id==request.id
                    //  && x.IsDeleted==false
                     ).FirstOrDefaultAsync();
                    if(isExist!=null)
                    {
                  //  isExist.IsDeleted = true;               
                    isExist.LastModificationTime = DateTime.UtcNow;
                    isExist.LastModifierUserId = 0;
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    CourseGradeVm model=new CourseGradeVm(){
                    id=isExist.Id,
                    courseid=isExist.CourseId,                    
                    gradeid=isExist.Gradeid
                };
                        res.data = model;
                        res.response_code = 0;
                        res.message = "CourseGrade Deleted";
                        res.status = "Success";
                        res.ReturnCode = 200;                        
                    } else {                        
                        res.response_code = 1;
                        res.message = "Already Exist";
                        res.status = "Unsuccess";
                        res.ReturnCode = 401;
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