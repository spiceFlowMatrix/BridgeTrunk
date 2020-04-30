using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bridge.Application.Interfaces;
using Bridge.Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Courses.Queries.GetCourseList {
    // Updated by Arjun Singh 
    public class GetCourseListQueryHandler : IRequestHandler<GetCourseListQuery, ApiResponse> {
        private readonly IBridgeDbContext _dbContext;
        public GetCourseListQueryHandler (IBridgeDbContext dbContext) {
            _dbContext = dbContext;
        }
        public async Task<ApiResponse> Handle (GetCourseListQuery request, CancellationToken cancellationToken) {
            ApiResponse res = new ApiResponse ();
            try {
                if (request.search != "") {
                    var courseList = await _dbContext.Course.Where (x => x.IsDeleted == false &&
                            (x.Code.ToLower ().Contains (request.search.ToLower ()) ||
                                x.Name.ToLower ().Contains (request.search.ToLower ()) ||
                                x.Id.ToString ().ToLower ().Contains (request.search.ToLower ()))
                        ).Select (x => new {
                            x.Id,
                                x.Code,
                                x.Name,
                                x.Culture,
                                x.Status
                        }).AsQueryable ()
                        .Skip (request.perPageRecord * request.pageNumber)
                        .Take (request.perPageRecord)
                        .ToListAsync ();
                    res.totalcount = courseList.Count;
                    res.data = courseList.OrderByDescending (x => x.Code);
                } else {
                    var courseList = await _dbContext.Course.Where (x => x.IsDeleted == false).Select (x => new {
                            x.Id,
                                x.Code,
                                x.Name,
                                x.Culture,
                                x.Status
                        }).AsQueryable ()
                        .Skip (request.perPageRecord * request.pageNumber)
                        .Take (request.perPageRecord)
                        .ToListAsync ();
                    res.totalcount = courseList.Count;
                    res.data = courseList.OrderByDescending (x => x.Code);
                }
                
                res.response_code = 0;
                res.message = "Course Details";
                res.status = "Success";
                res.ReturnCode = 200;
            } catch (Exception ex) {
                res.response_code = 2;
                res.message = ex.Message;
                res.status = "Failure";
                res.ReturnCode = 500;
            }
            return res;
        }
    }
}