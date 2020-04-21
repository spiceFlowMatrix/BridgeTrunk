using System;
using Application.Helpers;
using AutoMapper;
using Bridge.Application.Mappings;
using Bridge.Persistence;
using Rest.Courses.Services;
using Xunit;

namespace Application.CoursesUnitTests.Common {
    public class QueryTestFixture : IDisposable {
        public BridgeDbContext Context { get; private set; }
        public IMapper Mapper { get; private set; }
        public UserHelper _userHelper { get; private set; }
        public CurrentUserService _userService { get; private set; }

        public QueryTestFixture () {
            Context = BridgeContextFactory.Create ();
            _userService = new CurrentUserService (BridgeContextFactory.CreateHttpContext ());

            var configurationProvider = new MapperConfiguration (cfg => {
                cfg.AddProfile<MappingProfile> ();
            });

            Mapper = configurationProvider.CreateMapper ();
            _userHelper = new UserHelper (Context);
        }

        public void Dispose () {
            BridgeContextFactory.Destroy (Context);
        }
    }

    [CollectionDefinition ("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}