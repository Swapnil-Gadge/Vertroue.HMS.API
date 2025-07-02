using Vertroue.HMS.API.Domain.Entities;
using Vertroue.HMS.API.Persistence;

namespace Vertroue.HMS.API.API.IntegrationTests.Base
{
    public class Utilities
    {
        public static void InitializeDbForTests(ApiDbContext context)
        {
            var seafoodGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var dairyGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var beverageGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var cerealGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

            context.Categories.Add(new Category
            {
                CategoryId = seafoodGuid,
                Name = "Seafood"
            });
            context.Categories.Add(new Category
            {
                CategoryId = dairyGuid,
                Name = "Dairy"
            });
            context.Categories.Add(new Category
            {
                CategoryId = beverageGuid,
                Name = "Beverage"
            });
            context.Categories.Add(new Category
            {
                CategoryId = cerealGuid,
                Name = "Cereal"
            });

            context.SaveChanges();
        }
    }
}
