using Automat.Common;
using Automat.Domain;
using System.Collections.Generic;

namespace Automat.Application.Abstraction
{
    public interface IProductService
    {
        public Result<IEnumerable<ProductDto>> GetListByCodes (List<int> productCodes);
    }
}