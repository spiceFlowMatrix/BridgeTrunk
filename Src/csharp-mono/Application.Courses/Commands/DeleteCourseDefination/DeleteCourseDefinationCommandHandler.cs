using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Helpers;
using Application.Interfaces;
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
        private readonly ICurrentUserService _userService;
        private readonly IUserHelper _userHelper;


        public DeleteCourseDefinationCommandHandler(IBridgeDbContext dbContext, ICurrentUserService userService,IUserHelper userHelper)
        {
            _dbContext = dbContext;
            _userService = userService;
            _userHelper = userHelper;
        }
        public async Task<ApiResponse> Handle(DeleteCourseDefinationCommand request, CancellationToken cancellationToken)
        {
            ApiResponse res = new ApiResponse();
            try
            {
                if (_userService.RoleList.Contains(Roles.admin.ToString()))
                {
                    var userId = await _userHelper.getUserId(_userService.UserId.ToString());
                  
                    CourseDefination ifExistCourseDefinition = await _dbContext.CourseDefination.FirstOrDefaultAsync(x => x.Id == request.Id);
                    if (ifExistCourseDefinition != null)
                    {
                        // ifExistCourseDefinition.IsDeleted = true;
                        ifExistCourseDefinition.LastModifierUserId = int.Parse(userId);
                        ifExistCourseDefinition.LastModificationTime = DateTime.UtcNow.ToString();
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
                else
                {
                    res.response_code = 1;
                    res.message = "You are not authorized.";
                    res.status = "Unsuccess";
                    res.ReturnCode = 401;
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