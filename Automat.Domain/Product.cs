using System.ComponentModel.DataAnnotations;

namespace Automat.Domain
{
    public class Product : BaseEntity
    {
        public int Quantity { get; set; }

        [MaxLength(150)]
        public string Name { get; set; }
        public double Price { get; set; }
        public int ProductCode { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}
