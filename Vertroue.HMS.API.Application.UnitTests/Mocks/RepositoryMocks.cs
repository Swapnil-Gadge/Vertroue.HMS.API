﻿using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Domain.Entities;

using Moq;

namespace Vertroue.HMS.API.Application.UnitTests.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IAsyncRepository<Category>> GetCategoryRepository()
        {
            var seafoodGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var dairyGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var beverageGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var cerealGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

            var categories = new List<Category>
            {
                new Category
                {
                    CategoryId = seafoodGuid,
                    Name = "Seafood"
                },
                new Category
                {
                    CategoryId = dairyGuid,
                    Name = "Dairy"
                },
                new Category
                {
                    CategoryId = beverageGuid,
                    Name = "Beverage"
                },
                 new Category
                {
                    CategoryId = cerealGuid,
                    Name = "Cereal"
                }
            };

            var mockCategoryRepository = new Mock<IAsyncRepository<Category>>();
            mockCategoryRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(categories);

            mockCategoryRepository.Setup(repo => repo.AddAsync(It.IsAny<Category>())).ReturnsAsync(
                (Category category) =>
                {
                    categories.Add(category);
                    return category;
                });

            return mockCategoryRepository;
        }
    }
}
