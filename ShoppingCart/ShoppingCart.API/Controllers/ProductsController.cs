using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Core.Domain;
using ShoppingCart.Core.Interface;

namespace ShoppingCart.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository) 
        {
            this._productRepository = productRepository;
        }
        public IEnumerable<Product> Get()
        {
            return _productRepository.Get();
        }
    }
}