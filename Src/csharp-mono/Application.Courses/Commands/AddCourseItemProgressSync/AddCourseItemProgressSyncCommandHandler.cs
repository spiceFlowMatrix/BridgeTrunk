using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using MediatR;
using Bridge.Application.Models;
using Bridge.Domain.Entities;
using Bridge.Application.Interfaces;

namespace Application.Courses.Commands.AddCourseItemProgressSync
{
    public class AddCourseItemProgressSyncCommandHandler: IRequestHandler<AddCourseItemProgressSyncCommand, ApiResponse>
    {
        private readonly IBridgeDbContext _dbContext;
        public AddCourseItemProgressSyncCommandHandler(IBridgeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApiResponse> Handle(AddCourseItemProgressSyncCommand request, CancellationToken cancellationToken)
        {
            ApiResponse res = new ApiResponse();
            try
            {
                foreach (var courseItemProgress in request.addCourseItemProgressSyncs)
                {
                    _dbContext.CourseItemProgressSync.Add(new CourseItemProgressSync()
                    {
                        Lessonid = courseItemProgress.lessonid,
                        Lessonprogress = courseItemProgress.lessonprogress,
                        
                        Quizid = courseItemProgress.quizid,
                        // CreationTime = DateTime.Now.ToString()
                    });
                    await _dbContext.SaveChangesAsync(cancellationToken);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return res;
        }
    }
}