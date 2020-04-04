using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bridge.Application.Interfaces;
using Bridge.Application.Models;
using Bridge.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Courses.Queries.GetCoursePreviewById
{
    public class GetCoursePreviewByIdQueryHandler : IRequestHandler<GetCoursePreviewByIdQuery, ApiResponse> {
        private readonly IBridgeDbContext _dbContext;
        public GetCoursePreviewByIdQueryHandler (IBridgeDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<ApiResponse> Handle (GetCoursePreviewByIdQuery request, CancellationToken cancellationToken) {
            ApiResponse res = new ApiResponse ();
            try {        
                string Certificate = Path.GetFileName("../../training24-28e994f9833c.json");
                } catch (Exception ex) {
                res.ReturnCode = 500;
                res.response_code = 2;
                res.message = ex.Message;
                res.status = "Failure";
            }
            return res;
        }                        
    }
}