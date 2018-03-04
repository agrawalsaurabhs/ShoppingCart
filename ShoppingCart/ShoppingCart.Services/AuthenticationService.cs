using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Core;
using ShoppingCart.Core.Interface;

namespace ShoppingCart.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;

        public AuthenticationService(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }
        public async Task<bool> Authenticate(string username, string password)
        {
           return await _authenticationRepository.Authenticate(username, password);
        }
    }
}
