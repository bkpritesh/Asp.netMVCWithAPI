 
namespace web.ApiInfrastructure.ApiModels
{ 

    public class RegisterApiModel  
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}