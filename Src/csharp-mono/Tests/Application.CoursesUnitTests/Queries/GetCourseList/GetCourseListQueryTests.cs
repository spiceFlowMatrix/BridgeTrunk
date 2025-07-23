using System.Threading;
using System.Threading.Tasks;
using Application.Courses.Queries.GetCourseList;
using Application.CoursesUnitTests.Common;
using Bridge.Persistence;
using Microsoft.AspNetCore.Http;
using Shouldly;
using Xunit;

namespace Application.CoursesUnitTests.Queries.GetCourseList
{
    [Collection ("QueryCollection")]

    // Updated by Arjun Singh 29/04/2020
    public class GetCourseListQueryTests {
        private readonly BridgeDbContext _context;

        public GetCourseListQueryTests (QueryTestFixture fixture) {
            _context = fixture.Context;
        }

        [Fact]
        public async Task Get_WhenCall_ReturnCode () {
            var sut = new GetCourseListQueryHandler (_context);
            GetCourseListQuery query = new GetCourseListQuery {
                pageNumber = 0,
                perPageRecord = 5,
                search = ""
            };

            var result = await sut.Handle (query, CancellationToken.None);

            result.ReturnCode.ShouldBe (StatusCodes.Status200OK);
        }

        [Fact]
        public async Task Get_WhenCall_ReturnData () {
            var sut = new GetCourseListQueryHandler (_context);
            GetCourseListQuery query = new GetCourseListQuery {
                pageNumber = 0,
                perPageRecord = 5,
                search = ""
            };

            var result = await sut.Handle (query, CancellationToken.None);

            result.totalcount.ShouldBe (7);
        }

        [Fact]
        public async Task Get_WhenCallOnSearch_ReturnData () {
            var sut = new GetCourseListQueryHandler (_context);
            GetCourseListQuery query = new GetCourseListQuery {
                pageNumber = 0,
                perPageRecord = 5,
                search = "1"
            };

            var result = await sut.Handle (query, CancellationToken.None);
            result.totalcount.ShouldBe (1);
        }

    }
}