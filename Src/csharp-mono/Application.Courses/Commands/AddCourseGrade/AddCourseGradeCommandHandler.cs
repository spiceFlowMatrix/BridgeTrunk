using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bridge.Domain.Entities;
using Bridge.Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Bridge.Application.Interfaces;

namespace Application.Courses.Commands.AddCourseGrade
{
    public class AddCourseGradeCommandHandler : IRequestHandler<AddCourseGradeCommand, ApiResponse>
    {
        private readonly IBridgeDbContext _dbContext;
        public AddCourseGradeCommandHandler (IBridgeDbContext dbContext) {
            _dbContext = dbContext;
        }
  
        public async Task<ApiResponse> Handle(AddCourseGradeCommand request, CancellationToken cancellationToken)
        {
            ApiResponse res = new ApiResponse();
            try {
            var isExist = await _dbContext.CourseGrade.Where(x=>x.CourseId==request.courseid
            //  && x.IsDeleted==false
             ).FirstOrDefaultAsync();
            if(isExist==null)
            {
                CourseGrade obj= new CourseGrade(){
                CourseId = request.courseid,
                Gradeid = request.gradeid,
               // IsDeleted = false,
                CreationTime = DateTime.UtcNow,
                CreatorUserId = 0
                };
                await _dbContext.CourseGrade.AddAsync(obj);
                await _dbContext.SaveChangesAsync(cancellationToken);
                CourseGradeVm model=new CourseGradeVm(){
                    id=obj.Id,
                    courseid=obj.CourseId,                    
                    gradeid=obj.Gradeid
                };
                res.data = model;
                res.response_code = 0;
                res.message = "CourseGrade Created";
                res.status = "Success";
                res.ReturnCode = 200;
            } else {
                if(isExist.Gradeid != request.gradeid)
                {                       
                    isExist.CourseId = request.courseid;
                    isExist.Gradeid = request.gradeid;                    
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
            } 
            catch(Exception ex){
                res.ReturnCode = 500;
                res.response_code = 1;
                res.message = ex.Message;
                res.status = "Failure";
            }
            return res;
        }
    }
}