using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Domain.Entities;

using FluentAssertions;

using Microsoft.EntityFrameworkCore;

using Moq;

namespace Vertroue.HMS.API.Persistence.IntegrationTests
{
    public class ApiDbContextTests
    {
        private readonly ApiDbContext _modulenameDbContext;
        private readonly Mock<ILoggedInUserService> _loggedInUserServiceMock;
        private readonly string _loggedInUserId;

        public ApiDbContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ApiDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _loggedInUserId = "xyz@mandg.com";
            _loggedInUserServiceMock = new Mock<ILoggedInUserService>();
            _loggedInUserServiceMock.Setup(m => m.UserId).Returns(_loggedInUserId);

            _modulenameDbContext = new ApiDbContext(dbContextOptions, _loggedInUserServiceMock.Object);
        }

        [Fact]
        public async void Save_SetCreatedByProperty()
        {
            var ev = new Product() {ProductId = Guid.NewGuid(), Name = "Test product" };

            _modulenameDbContext.Products.Add(ev);
            await _modulenameDbContext.SaveChangesAsync();

            ev.CreatedBy.Should().Be(_loggedInUserId);
        }
    }
}
