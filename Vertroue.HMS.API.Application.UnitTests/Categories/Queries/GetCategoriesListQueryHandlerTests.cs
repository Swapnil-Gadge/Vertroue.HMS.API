using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.Categories.Queries.GetCategoriesList;
using Vertroue.HMS.API.Application.Profiles;
using Vertroue.HMS.API.Application.UnitTests.Mocks;
using Vertroue.HMS.API.Domain.Entities;

using AutoMapper;

using FluentAssertions;

using Moq;

namespace Vertroue.HMS.API.Application.UnitTests.Categories.Queries
{
    public class GetCategoriesListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Category>> _mockCategoryRepository;

        public GetCategoriesListQueryHandlerTests()
        {
            _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetCategoriesListTest()
        {
            var handler = new GetCategoriesListQueryHandler(_mapper, _mockCategoryRepository.Object);

            var result = await handler.Handle(new GetCategoriesListQuery(), CancellationToken.None);

            result.Should().BeOfType<List<CategoryListVm>>();

            result.Count.Should().Be(4);
        }
    }
}
