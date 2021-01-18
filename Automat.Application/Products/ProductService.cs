using Automat.Application.Abstraction;
using Automat.Common;
using Automat.Data;
using Automat.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Automat.Application
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        /// <summary>
        /// Stok kontrolü, ürün bilgileri gibi durumları servisten kontrol edebiliriz.
        /// </summary>
        /// <param name="productCodes"></param>
        /// <returns></returns>
        public Result<IEnumerable<ProductDto>> GetListByCodes(List<int> productCodes)
        {
            var data = _productRepository.GetList(x => productCodes.Any(p => p == x.ProductCode), null, x => x.Include(c => c.Category)).Select(s => new ProductDto()
            {
                CategoryId = s.CategoryId,
                CategoryType = s.Category.CategoryType,
                Name = s.Name,
                Price = s.Price,
                ProductCode = s.ProductCode,
                ProductId = s.Id,
                Description = ReturnDescription(s.Category.CategoryType, s.Name)
            });
            return new Result<IEnumerable<ProductDto>> { Data = data, Success = true, Message = "İşlem Başarılı" };
        }

        public string ReturnDescription(CategoryType categoryType, string name)
        {
            string message = "";
            switch (categoryType)
            {
                case CategoryType.Drink:
                    message = string.Format("Lütfen {0} ürünü için ürün adedini seçiniz!", name);
                    break;
                case CategoryType.HotDrink:
                    message = string.Format("Lütfen {0} ürünü için şeker adedini ve ürün adedini seçiniz!", name);
                    break;
                case CategoryType.Food:
                    message = string.Format("Lütfen {0} ürünü için ürün adedini seçiniz!", name);
                    break;
                default:
                    break;
            }
            return message;
        }
    }
}
