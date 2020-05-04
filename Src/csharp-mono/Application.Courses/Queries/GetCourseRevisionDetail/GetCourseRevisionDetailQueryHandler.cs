using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bridge.Application.Interfaces;
using Bridge.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Courses.Queries.GetCourseRevisionDetail {
    public class GetCourseRevisionDetailQueryHandler : IRequestHandler<GetCourseRevisionDetailQuery, ApiResponse> {
        private readonly IBridgeDbContext _dbContext;
        public GetCourseRevisionDetailQueryHandler (IBridgeDbContext dbContext) {
            _dbContext = dbContext;
        }
        public async Task<ApiResponse> Handle (GetCourseRevisionDetailQuery request, CancellationToken cancellationToken) {
            ApiResponse res = new ApiResponse ();
            try {

                var revisionDetails = await (from cr in _dbContext.CourseRevision.AsNoTracking ()
                    .Where (x => x.Id == request.RevisionId && x.IsDeleted == false) 
                    join c in _dbContext.Course.AsNoTracking () on cr.CourseId equals c.Id into crc 
                    from c in crc.DefaultIfEmpty ()
                    join t in _dbContext.Teacher.AsNoTracking () on c.TeacherId equals t.Id into tc 
                    from t in tc.DefaultIfEmpty () select new CourseRevisionDetailVm {
                        RevisionDetails = new RevisionDetail {
                                RevisionId = cr.Id,
                                    RevisionName = cr.RevisionName,
                                    Summary = cr.Summary,
                                    AdministeredOn = cr.AdministeredOn,
                                    AdministeredBy = cr.AdministeredBy,
                                    PublishedOn = cr.PublishedOn,
                                    PublishedBy = cr.PublishedBy,
                                    ReleasedOn = cr.ReleasedOn,
                                    ReleasedBy = cr.ReleasedBy
                            },
                            CourseDetails = new CourseDetail {
                                Name = c.Name,
                                    Code = c.Code,
                                    Description = c.Description,
                                    Culture = c.Culture,
                                    TeacherName = t.FullName
                            }
                    }

                ).FirstOrDefaultAsync ();
                if (revisionDetails != null) {
                    res.data = revisionDetails;
                    res.response_code = 0;
                    res.message = "Course Revision Details";
                    res.status = "Success";
                    res.ReturnCode = StatusCodes.Status200OK;
                } else {
                    res.response_code = 1;
                    res.message = "Course Revision Details Not Found";
                    res.status = "NotFound";
                    res.ReturnCode = StatusCodes.Status404NotFound;
                }
            } catch (Exception ex) {
                res.response_code = 2;
                res.message = ex.Message;
                res.status = "Failure";
                res.ReturnCode = StatusCodes.Status500InternalServerError;
            }
            return res;
        }
    }
}