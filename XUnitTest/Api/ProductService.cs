using Automat.Application.Abstraction;
using Automat.Common;
using Automat.Data;
using Automat.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace XUnitTest
{
    public class MoqProductService : IProductService
    {
        public MoqProductService()
        {

        }
        /// <summary>
        /// Business kodu içermediği için direkt servis moqlandı. Normal şartlarda repository moqlanabilir.
        /// </summary>
        /// <param name="productCodes"></param>
        /// <returns></returns>
        public Result<IEnumerable<ProductDto>> GetListByCodes(List<int> productCodes)
        {
            var productlist = new List<ProductDto>()
            {
                new ProductDto{CategoryId = 1,CategoryType=CategoryType.Drink,Name="Cola",Price=3,ProductCode=300,ProductId=3,Description="Test1"},
                new ProductDto{CategoryId = 3,CategoryType=CategoryType.Drink,Name="Kahve",Price=5,ProductCode=500,ProductId=5,Description="Test2"},
            };

            return new Result<IEnumerable<ProductDto>> { Data = productlist, Success = true, Message = "İşlem Başarılı" };
        }
    }
}
