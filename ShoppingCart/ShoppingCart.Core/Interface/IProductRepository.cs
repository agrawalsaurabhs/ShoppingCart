using System.Collections.Generic;
using ShoppingCart.Core.Domain;

namespace ShoppingCart.Core.Interface
{
    public interface IProductRepository
    {
        IEnumerable<Product> Get();
    }
}