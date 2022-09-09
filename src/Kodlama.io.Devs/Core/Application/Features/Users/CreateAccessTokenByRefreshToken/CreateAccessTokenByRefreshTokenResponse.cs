namespace Application.Features.Users.CreateAccessTokenByRefreshToken
{
    public class CreateAccessTokenByRefreshTokenResponse
    {
        public CreateAccessTokenByRefreshTokenResponse(string accessToken, DateTime accessTokenExpiration)
        {
            AccessToken = accessToken;
            AccessTokenExpiration = accessTokenExpiration;
        }

        public string AccessToken { get; set; }
        public DateTime AccessTokenExpiration { get; set; }
    }
}
