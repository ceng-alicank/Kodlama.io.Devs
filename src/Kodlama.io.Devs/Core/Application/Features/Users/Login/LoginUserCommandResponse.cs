namespace Application.Features.Users.Login
{
    public class LoginUserCommandResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
