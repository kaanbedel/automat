using Automat.Application.Abstraction;
using Automat.Common;
using Automat.Data;
using Automat.Domain;
using Automat.Persistence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Moq;
using OdeAl.Api.Controllers;
using OdeAl.Api.Model;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTest
{
    public class ProductControllerTest
    {
        private Mock<MoqProductService> _productService;
        public ProductControllerTest()
        {
            this._productService = new Mock<MoqProductService>();

        }
        [Fact]
        public void Select_Product()
        {
            List<int> codes = new List<int>();
            codes.Add(300);
            codes.Add(500);
            var controller = this.CreateProductController();
            controller.SelectProduct(codes);
        }
        [Fact]
        public void Buy_Product()
        {
            ProductViewModel model = new ProductViewModel()
            {
                Money = 10,
                PaymentType = 0,
                ProductModel = new List<ProductModel>()
                {
                    new ProductModel {
                        ProductName="Cola",
                        ProductCode=300,
                        Quantity=1,
                        Price=3,
                        Sugar=0
                    },
                    new ProductModel {
                        ProductName="Kahve",
                        ProductCode=500,
                        Quantity=1,
                        Price=5,
                        Sugar=2
                    }
                }
            };
            var controller = this.CreateProductController();
            controller.BuyProduct(model);
        }
        private ProductController CreateProductController()
        {
            var httpContext = new DefaultHttpContext();

            var controller = new ProductController(productService: this._productService.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = httpContext,
                },
            };
            return controller;
        }
    }
}
