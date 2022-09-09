namespace Application.Features.Users.Create
{
    public class CreateUserCommandResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
