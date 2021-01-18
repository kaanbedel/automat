using OdeAl.Api.Model.Enum;
using System.Collections.Generic;
 

namespace OdeAl.Api.Model
{
    public class ProductViewModel
    {
        public List<ProductModel> ProductModel { get; set; }
        public PaymentType PaymentType { get; set; }
        public decimal Money { get; set; }
    }
}
