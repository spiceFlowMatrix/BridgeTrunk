using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bridge.Domain.Entities;
using Bridge.Persistence;
using MediatR;

namespace Application.Courses.Commands.UpsertCourseGrade {
    public class UpsertCourseGradeCommandHandler : IRequestHandler<UpsertCourseGradeCommand, object> {
        private readonly BridgeDbContext _dbContext;
        public UpsertCourseGradeCommandHandler (BridgeDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<object> Handle (UpsertCourseGradeCommand request, CancellationToken cancellationToken) {
            try {
                var isExist = _dbContext.CourseGrade.Where (x => x.CourseId == request.courseid).FirstOrDefault ();
                if (isExist == null) {
                    CourseGrade obj = new CourseGrade () {
                    CourseId = request.courseid,
                    Gradeid = request.gradeid,
                    IsDeleted = false,
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = 0
                    };
                    await _dbContext.CourseGrade.AddAsync (obj);
                    await _dbContext.SaveChangesAsync ();
                } else {
                    if (isExist.Gradeid == request.gradeid) {
                        isExist.CourseId = request.courseid;
                        isExist.Gradeid = request.gradeid;
                        isExist.IsDeleted = false;
                        isExist.LastModifiedOn = DateTime.UtcNow;
                        isExist.LastModifiedBy = 0;
                        await _dbContext.SaveChangesAsync ();
                    }
                }
                return "ghj";
            } catch (Exception ex) {
                return ex;
            }
        }
    }
}