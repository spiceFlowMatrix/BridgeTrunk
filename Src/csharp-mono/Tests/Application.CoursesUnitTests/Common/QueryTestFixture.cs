using System;
using AutoMapper;
using Bridge.Application.Mappings;
using Bridge.Persistence;
using Xunit;

namespace Application.CoursesUnitTests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public BridgeDbContext Context { get; private set; }
        public IMapper Mapper { get; private set; }

        public QueryTestFixture()
        {
            Context = BridgeContextFactory.Create();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            BridgeContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}