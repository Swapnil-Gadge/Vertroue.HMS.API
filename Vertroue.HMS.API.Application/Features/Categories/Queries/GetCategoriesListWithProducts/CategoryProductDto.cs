namespace Vertroue.HMS.API.Application.Features.Categories.Queries.GetCategoriesListWithProducts
{
    public class CategoryProductDto
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int UnitPrice { get; set; }
        public Guid CategoryId { get; set; }
    }
}
