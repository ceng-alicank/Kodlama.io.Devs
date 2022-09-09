namespace Application.Features.Users.Create
{
    public class CreateUserCommandResponse
    {
        public CreateUserCommandResponse(string accessToken, DateTime accessTokenExpiration, string refreshToken, DateTime refreshTokenExpiration)
        {
            AccessToken = accessToken;
            AccessTokenExpiration = accessTokenExpiration;
            RefreshToken = refreshToken;
            RefreshTokenExpiration = refreshTokenExpiration;
        }

        public string AccessToken { get; set; }
        public DateTime AccessTokenExpiration { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }
}
