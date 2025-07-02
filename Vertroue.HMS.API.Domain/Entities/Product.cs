using Vertroue.HMS.API.Domain.Common;

namespace Vertroue.HMS.API.Domain.Entities
{
    public class Product : AuditableEntity
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int UnitPrice { get; set; }        
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = default!;

    }
}
