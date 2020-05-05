using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bridge.Application.Interfaces;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Courses.Queries.GetLessonByChapterId
{
    public class GetLessonsByChapterIdQueryHandler : IRequestHandler<GetLessonsByChapterIdQuery, object>
    {
        private readonly IBridgeDbContext _dbContext;
        public GetLessonsByChapterIdQueryHandler(IBridgeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<object> Handle(GetLessonsByChapterIdQuery request, CancellationToken cancellationToken)
        {

            List<GetLessonsByChapterIdVm> response = new List<GetLessonsByChapterIdVm>();
            try
            {
                response = await _dbContext.Lesson.Where(x => x.IsDeleted == false &&
                                                                    x.ChapterId == request.Id)
                                                        .Select(x => new GetLessonsByChapterIdVm
                                                        {
                                                            Id = x.Id,
                                                            Title = x.Title,
                                                            Status = x.Status,
                                                            StatusName = ((CourseStatus)x.Status).ToString(),
                                                            LessonType = x.LessonType,
                                                            LessonTypeName = ((LessonType)x.LessonType).ToString(),
                                                        }).ToListAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return response;
        }
    }
}