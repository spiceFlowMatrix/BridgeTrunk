using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using MediatR;
using Bridge.Application.Models;
using Bridge.Domain.Entities;
using Bridge.Application.Interfaces;
using Application.Interfaces;

namespace Application.Courses.Commands.AddCourseItemProgressSync
{
    public class AddCourseItemProgressSyncCommandHandler: IRequestHandler<AddCourseItemProgressSyncCommand, ApiResponse>
    {
        private readonly IBridgeDbContext _dbContext;
        private readonly ICurrentUserService _userService;
        private readonly IUserHelper _userHelper;
        public AddCourseItemProgressSyncCommandHandler(IBridgeDbContext dbContext, ICurrentUserService userService, IUserHelper userHelper)
        {
            _dbContext = dbContext;
            _userService = userService;
            _userHelper = userHelper;
        }

        public async Task<ApiResponse> Handle(AddCourseItemProgressSyncCommand request, CancellationToken cancellationToken)
        {
            ApiResponse res = new ApiResponse();
            try
            {
                var userId = await _userHelper.getUserId(_userService.UserId.ToString());
                foreach (var courseItemProgress in request.addCourseItemProgressSyncs)
                {
                    _dbContext.CourseItemProgressSync.Add(new CourseItemProgressSync()
                    {
                        Lessonid = courseItemProgress.lessonid,
                        Lessonprogress = courseItemProgress.lessonprogress,
                        
                        Quizid = courseItemProgress.quizid,
                        CreationTime = DateTime.Now.ToString(),
                        CreatorUserId = int.Parse(userId)
                    });  
                }
                await _dbContext.SaveChangesAsync(cancellationToken);
                res.data = request.addCourseItemProgressSyncs;
                res.response_code = 0;
                res.message = "CourseItemProgressSync";
                res.status = "Success";
                res.ReturnCode = 200;
            }
            catch (Exception ex)
            {
                res.response_code = 2;
                res.message = ex.Message;
                res.status = "Failure";
                res.ReturnCode = 500;
            }
            return res;
        }
    }
}