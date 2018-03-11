using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Core.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }
    }
}
