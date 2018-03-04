using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Core.Interface
{
    public interface IAuthenticationService
    {
       Task<bool> Authenticate(string username, string password);
    }
}
