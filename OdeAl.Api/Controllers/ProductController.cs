using System.Collections.Generic;
using System.Linq;
using Automat.Application;
using Automat.Common;
using Microsoft.AspNetCore.Mvc;
using OdeAl.Api.Model;
using OdeAl.Api.Model.Enum;
using Automat.Application.Abstraction;

namespace OdeAl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        PaymentOperationStrategy paymentOperationStrategy = null;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("hello-products")]
        public ActionResult<string> Index()
        {
            return "Hello World!";
        }

        /// <summary>
        /// Bir arayüzümüzün olduğunu varsayıyoruz. 
        /// Arayüzde ürün adedi seçtiğimizi varsayalım.
        /// Ürün bilgilerini içeren dto'yu viewmodele map'leyip ara yüze gönderdiğimizi düşünelim.
        /// </summary>
        /// <param name="productCodes"></param>
        /// <returns></returns>
        [HttpGet("select-products")]
        public ActionResult<string> SelectProduct(List<int> productCodes)
        {
            var productList = GetProductListByCodes(productCodes);
            var messageJoin = string.Join("\n", productList.Select(x => x.Description));
            return messageJoin;
        }

        /// <summary>
        /// Ürün ile ilgili bilgileri içeren viewmodel ile arayüzden ödeme tipini ve para bilgisini alıp talebi ilettiğimizi varsayıyoruz.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="paymentType"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        [HttpPost("buy-products")]
        public ActionResult<string> BuyProduct([FromBody]ProductViewModel model)
        {
            decimal totalPrice = GetProductTotalPrice(model.ProductModel);
            CreatePaymentType(model.PaymentType);
            var result = paymentOperationStrategy.MakePayment(model.Money, totalPrice);
            return string.Format("Seçilen {0} adet ürün için {1}", model.ProductModel.Count, result.message);
        }

        private void CreatePaymentType(PaymentType paymentType)
        {
            switch (paymentType)
            {
                case PaymentType.CreditCard:
                    paymentOperationStrategy = new PaymentOperationStrategy(new CreditCardPaymentService());
                    break;
                case PaymentType.CreditCardContacless:
                    paymentOperationStrategy = new PaymentOperationStrategy(new CreditCardContactlessPaymentService());
                    break;
                case PaymentType.Banknotes:
                    paymentOperationStrategy = new PaymentOperationStrategy(new CashPaymentService());
                    break;
                case PaymentType.Coin:
                    paymentOperationStrategy = new PaymentOperationStrategy(new CoinPaymentService());
                    break;
                default:
                    break;
            }
        }

        public IEnumerable<ProductDto> GetProductListByCodes(List<int> productCodes)
        {
            return _productService.GetListByCodes(productCodes).Data;
        }
        private decimal GetProductTotalPrice(List<ProductModel> model)
        {
            decimal total = 0;
            foreach (var item in model)
            {
                total += item.Price;
            }
            return total;
        }

    }
}
