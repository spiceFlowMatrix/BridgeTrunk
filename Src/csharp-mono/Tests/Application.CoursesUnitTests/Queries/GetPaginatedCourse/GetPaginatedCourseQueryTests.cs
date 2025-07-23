using System.Threading;
using System.Threading.Tasks;
using Application.Courses.Queries.GetPaginatedCourse;
using Application.CoursesUnitTests.Common;
using Application.Helpers;
using Bridge.Persistence;
using Microsoft.AspNetCore.Http;
using Shouldly;
using Xunit;

namespace Application.CoursesUnitTests.Queries.GetPaginatedCourse {
    [Collection ("QueryCollection")]
    // Updated by Arjun Singh 29/04/2020
    public class GetPaginatedCourseQueryTests {
        private readonly BridgeDbContext _context;
        private readonly UserHelper _userHelper;

        public GetPaginatedCourseQueryTests (QueryTestFixture fixture) {
            _context = fixture.Context;
            _userHelper = fixture._userHelper;
        }

        [Fact]
        public async Task GetPaginatedCourseTest () {
            var sut = new GetPaginatedCourseQueryHandler (_context, _userHelper);
            GetPaginatedCourseQuery query = new GetPaginatedCourseQuery {
                pageNumber = 0,
                perPageRecord = 5,
                search = "test"
            };

            var result = await sut.Handle (query, CancellationToken.None);

            result.ReturnCode.ShouldBe (StatusCodes.Status200OK);
        }

        [Fact]
        public async Task Get_WhenCall_ReturnData () {
            var sut = new GetPaginatedCourseQueryHandler (_context, _userHelper);
            GetPaginatedCourseQuery query = new GetPaginatedCourseQuery {
                pageNumber = 1,
                perPageRecord = 5,
                search = ""
            };

            var result = await sut.Handle (query, CancellationToken.None);

            result.totalcount.ShouldBe (7);
        }

        [Fact]
        public async Task Get_WhenCallOnSearch_ReturnData () {
            var sut = new GetPaginatedCourseQueryHandler (_context, _userHelper);
            GetPaginatedCourseQuery query = new GetPaginatedCourseQuery {
                pageNumber = 0,
                perPageRecord = 5,
                search = "1"
            };

            var result = await sut.Handle (query, CancellationToken.None);
            result.totalcount.ShouldBe (1);
        }

    }
}