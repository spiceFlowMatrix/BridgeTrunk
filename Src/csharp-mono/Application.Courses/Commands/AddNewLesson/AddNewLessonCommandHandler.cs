using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bridge.Application.Interfaces;
using Bridge.Domain.Entities;
using MediatR;

namespace Application.Courses.Commands.AddNewLesson
{
    public class AddNewLessonCommandHandler : IRequestHandler<AddNewLessonCommand, object>
    {

        private readonly IBridgeDbContext _dbContext;
        private readonly ICurrentUserService _userService;
        public AddNewLessonCommandHandler(IBridgeDbContext dbContext, ICurrentUserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }

        public async Task<object> Handle(AddNewLessonCommand request, CancellationToken cancellationToken)
        {
            Dictionary<string, object> response = new Dictionary<string, object>();

           try
           {
               Lesson lesson = new Lesson
               {
                   CreationTime = DateTime.UtcNow.ToString(),
                   IsDeleted = false,
                   Description = request.Description,
                   LessonType = request.LessonType,
                   Status = request.Status,
                   Title = request.Title,
                   CreatorUserId = _userService.UserId
               };

                _dbContext.Lesson.Add(lesson);
                await _dbContext.SaveChangesAsync(cancellationToken);
                response.Add("Success", true);
                response.Add("Id", lesson.Id);               
           }
           catch(Exception ex)
           {
               throw ex;
           }

           return response;
        }
    }
}