using System.Collections.Generic;
using System.Threading.Tasks;
using web.ApiHelper.Client;
using web.ApiHelper.Response;
using web.ApiInfrastructure.Responses;
using web.Models;
using web.Models.Authorize;

namespace web.ApiInfrastructure.Client
{
    public class LoginClient : ClientBase, ILoginClient
    { 
        private static readonly string BaseUrl = AppConst.WebApiUrl; 
        private static readonly string TokenUri = BaseUrl.Replace("/api","/") + "token";
        private static readonly string RegisterUri = BaseUrl + "register/Post";
        public LoginClient(IApiClient apiClient) : base(apiClient)
        {
        } 
        public async Task<TokenResponse> Login(string email, string password)
        {
            var response = await ApiClient.PostFormEncodedContent(TokenUri, "grant_type".AsPair("password"),
                "username".AsPair(email), "password".AsPair(password));
            var tokenResponse = await CreateJsonResponse<TokenResponse>(response);
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await DecodeContent<dynamic>(response);
                tokenResponse.ErrorState = new ErrorStateResponse
                {
                    ModelState = new Dictionary<string, string[]>
                    {
                        {errorContent["error"], new string[] {errorContent["error_description"]}}
                    }
                };
                return tokenResponse;
            }

            var tokenData = await DecodeContent<dynamic>(response);
            tokenResponse.Data = tokenData["access_token"];
            tokenResponse.Expires_In = tokenData["expires_in"];
            tokenResponse.FirstName = tokenData["FirstName"];
            tokenResponse.LastName = tokenData["LastName"];
            tokenResponse.Roles = tokenData["Roles"]; 
            return tokenResponse;
        }

        public async Task<RegisterResponse> Register(RegisterModel viewModel)
        {

            var response = await ApiClient.PostJsonEncodedContent(RegisterUri, viewModel);
            var registerResponse = await CreateJsonResponse<RegisterResponse>(response);
            return registerResponse;
        }
    }
}