using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCart.Core.Domain;
using ShoppingCart.Core.Interface;

namespace ShoppingCart.Data.Repositories
{
    class ProductRepository : IProductRepository
    {
        private readonly ShoppingDbContext _dbContext;

        public ProductRepository(ShoppingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Product> Get()
        {
            return _dbContext.Products;
        }
    }
}
