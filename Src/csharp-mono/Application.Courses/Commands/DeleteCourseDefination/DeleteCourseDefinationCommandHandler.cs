using System;
using System.Threading;
using System.Threading.Tasks;
using Bridge.Application.Interfaces;
using Bridge.Application.Models;
using Bridge.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Courses.Commands.DeleteCourseDefination
{
    public class DeleteCourseDefinationCommandHandler : IRequestHandler<DeleteCourseDefinationCommand, ApiResponse>
    {
        private readonly IBridgeDbContext _dbContext;
        public DeleteCourseDefinationCommandHandler(IBridgeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ApiResponse> Handle(DeleteCourseDefinationCommand request, CancellationToken cancellationToken)
        {
            ApiResponse res = new ApiResponse();
            try
            {
                CourseDefination ifExistCourseDefinition = await _dbContext.CourseDefination.FirstOrDefaultAsync(x => x.Id == request.Id );
                if (ifExistCourseDefinition != null)
                {
                    // ifExistCourseDefinition.IsDeleted = true;
                    ifExistCourseDefinition.LastModifiedBy = 0;
                    ifExistCourseDefinition.LastModifiedOn = DateTime.UtcNow;
                    await _dbContext.SaveChangesAsync(cancellationToken);

                    DeleteCourseDefinationVm vmObj = new DeleteCourseDefinationVm()
                    {
                        Id = ifExistCourseDefinition.Id,
                        GradeId = ifExistCourseDefinition.Id,
                        CourseId = ifExistCourseDefinition.CourseId,
                        Subject = ifExistCourseDefinition.Subject,
                        BasePrice = ifExistCourseDefinition.BasePrice,
                    };
                    res.data = vmObj;
                    res.response_code = 0;
                    res.message = "CourseDefination Deleted";
                    res.status = "Success";
                    res.ReturnCode = 200;
                }
                
            }
            catch (Exception ex)
            {
                res.ReturnCode = 500;
                res.response_code = 2;
                res.message = ex.Message;
                res.status = "Failure";
            }
            return res;
        }
    }
}