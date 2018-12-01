using System.Threading.Tasks;
using web.ApiInfrastructure.Responses;
using web.Models.Authorize;

namespace web.ApiInfrastructure.Client
{
    public interface ILoginClient
    {
        Task<TokenResponse> Login(string email, string password);
        Task<RegisterResponse> Register(RegisterModel viewModel);
    }
}