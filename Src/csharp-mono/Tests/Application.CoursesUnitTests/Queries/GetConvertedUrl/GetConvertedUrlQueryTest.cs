using System.Threading;
using System.Threading.Tasks;
using Application.Courses.Queries.GetConvertedUrl;
using Application.CoursesUnitTests.Common;
using Application.Helpers;
using Bridge.Persistence;
using Microsoft.AspNetCore.Hosting;
using Xunit;

namespace Application.CoursesUnitTests.Queries.GetConvertedUrl
{
    [Collection("QueryCollection")]
    public class GetConvertedUrlQueryTest 
    {
        private readonly BridgeDbContext _context;
        private readonly UserHelper _userHelper;
        private readonly IHostingEnvironment _env;

        public GetConvertedUrlQueryTest(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _userHelper = fixture._userHelper;
        }
        [Fact]
        public async Task GetConvertedUrlQueryHandlerTest()
        {
            var sut = new GetConvertedUrlQueryHandler(_env);
            GetConvertedUrlQuery query = new GetConvertedUrlQuery();
            var result = await sut.Handle(query, CancellationToken.None);
            result.ReturnCode = 200;
        }
    }
}