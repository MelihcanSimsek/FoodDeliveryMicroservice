namespace WebApp.Models.Login
{
    public class LoginResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expiration { get; set; }

        public LoginResponse()
        {
        }
    }
}
