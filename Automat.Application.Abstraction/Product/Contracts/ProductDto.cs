using Automat.Domain;

namespace Automat.Application.Abstraction
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int ProductCode { get; set; }
        public int CategoryId { get; set; }
        public CategoryType CategoryType { get; set; }
        public string Description { get; set; }
    }
}
