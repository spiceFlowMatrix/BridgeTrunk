using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Bridge.Persistence;
using System.Linq;
using System;
using Bridge.Domain.Entities;
using Bridge.Application.Models;

namespace Application.Courses.Commands.UpsertCourseGrade
{
    public class UpsertCourseGradeCommandHandler : IRequestHandler<UpsertCourseGradeCommand, ApiResponse>
    {
        private readonly BridgeDbContext _dbContext;
        public UpsertCourseGradeCommandHandler(BridgeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
  
        public async Task<ApiResponse> Handle(UpsertCourseGradeCommand request, CancellationToken cancellationToken)
        {
            ApiResponse res = new ApiResponse();
            try {
            var isExist = _dbContext.CourseGrade.Where(x=>x.CourseId==request.courseid).FirstOrDefault();
            if(isExist==null)
            {
                CourseGrade obj= new CourseGrade(){
                CourseId = request.courseid,
                Gradeid = request.gradeid,
                IsDeleted = false,
                CreatedOn = DateTime.UtcNow,
                CreatedBy = 0
                };
                await _dbContext.CourseGrade.AddAsync(obj);
                await _dbContext.SaveChangesAsync();
                // res.data = responseCourseGradeModel;
                res.response_code = 0;
                res.message = "CourseGrade Created";
                res.status = "Success";
                res.ReturnCode = 200;
            } else {
                if(isExist.Gradeid == request.gradeid)
                {
                    isExist.CourseId = request.courseid;
                    isExist.Gradeid = request.gradeid;
                    isExist.IsDeleted = false;
                    isExist.LastModifiedOn = DateTime.UtcNow;
                    isExist.LastModifiedBy = 0;
                    await _dbContext.SaveChangesAsync();
                }
            }
            } 
            catch(Exception ex){
                res.ReturnCode = 500;
                res.response_code = 1;
                res.message = ex.Message;
                res.status = "Unsuccess";
            }
            return res;
        }
    }
}