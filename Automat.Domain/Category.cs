using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Automat.Domain
{
    public class Category : BaseEntity
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }
        [MaxLength(50)]
        public string Name { get; set; }
        public CategoryType CategoryType { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
