using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using Bridge.Application.Interfaces;
using Bridge.Common;
using Bridge.Domain.Entities;
using Bridge.Persistence;
using Shouldly;
using Xunit;

namespace Persistence.IntegrationTests
{
    public class BridgeDbContextTests: IDisposable
    {
        private readonly int _userId;
        private readonly DateTime _dateTime;
        private readonly Mock<IDateTime> _dateTimeMock;
        private readonly Mock<ICurrentUserService> _currentUserServiceMock;
        private readonly BridgeDbContext _sut;

        public BridgeDbContextTests()
        {
            _dateTime = new DateTime(3001, 1, 1);
            _dateTimeMock = new Mock<IDateTime>();
            _dateTimeMock.Setup(m => m.Now).Returns(_dateTime);

            _userId = 1;
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _currentUserServiceMock.Setup(m => m.UserId).Returns(_userId.ToString());

            var options = new DbContextOptionsBuilder<BridgeDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _sut = new BridgeDbContext(options, _currentUserServiceMock.Object, _dateTimeMock.Object);

            _sut.School.Add(new School
            {
                Id = 1, 
                Code = "01",
                Name= "Public School"
            });

            _sut.SaveChanges();
        }

        [Fact]
        public async Task SaveChangesAsync_GivenNewSchool_ShouldSetCreatedProperties()
        {
            var school = new School
            {
                Id = 2,
                Name = "Private School"
            };

            _sut.School.Add(school);

            await _sut.SaveChangesAsync();

            school.CreationTime.ShouldBe(_dateTime.ToString());
            school.CreatorUserId.ShouldBe(_userId.ToString());
        }

        [Fact]
        public async Task SaveChangesAsync_GivenExistingSchool_ShouldSetLastModifiedProperties()
        {
            var school = await _sut.School.FindAsync(1L);

            school.Name = "Government School";

            await _sut.SaveChangesAsync();

            school.LastModificationTime.ShouldNotBeNull();
            school.LastModificationTime.ShouldBe(_dateTime.ToString());
            school.LastModifierUserId.ShouldBe(_userId.ToString());
        }

        public void Dispose()
        {
            _sut?.Dispose();
        }
        
    }
}