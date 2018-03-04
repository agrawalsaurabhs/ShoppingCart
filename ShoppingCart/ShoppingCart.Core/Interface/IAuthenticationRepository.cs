using System.Threading.Tasks;

namespace ShoppingCart.Core.Interface
{
    public interface IAuthenticationRepository
    {
        Task<bool> Authenticate(string username, string password);
    }
}