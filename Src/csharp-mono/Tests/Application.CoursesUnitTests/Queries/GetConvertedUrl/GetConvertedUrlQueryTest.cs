using System.Threading;
using System.Threading.Tasks;
using Application.Courses.Queries.GetConvertedUrl;
using Application.CoursesUnitTests.Common;
using Microsoft.AspNetCore.Hosting;
using Xunit;

namespace Application.CoursesUnitTests.Queries.GetConvertedUrl
{
    public class GetConvertedUrlQueryTest : CommandTestBase
    {
        private readonly IHostingEnvironment _env;
        [Fact]
        public async Task GetConvertedUrlQueryHandlerTest()
        {
            var sut = new GetConvertedUrlQueryHandler(_env);
            GetConvertedUrlQuery query = new GetConvertedUrlQuery();
            var result = await sut.Handle(query, CancellationToken.None);
            result.status = "Success";
        }
    }
}