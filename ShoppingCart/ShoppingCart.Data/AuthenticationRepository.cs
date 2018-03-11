using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ShoppingCart.Core.Domain;
using ShoppingCart.Core.Interface;

namespace ShoppingCart.Data
{
    public class AuthenticationRepository :IAuthenticationRepository
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthenticationRepository(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<bool> Authenticate(string username, string password)
        {
            var result = await this._signInManager.PasswordSignInAsync(username, password, false, false);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }
    }
}
