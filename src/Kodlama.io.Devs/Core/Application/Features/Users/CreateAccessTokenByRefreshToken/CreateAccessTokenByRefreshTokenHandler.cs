using Application.Features.Users.Create;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Users.CreateAccessTokenByRefreshToken
{
    public class CreateAccessTokenByRefreshTokenHandler : IRequestHandler<CreateAccessTokenByRefreshTokenRequest,CreateAccessTokenByRefreshTokenResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public CreateAccessTokenByRefreshTokenHandler(IUserRepository userRepository, IOperationClaimRepository operationClaimRepository, ITokenHelper tokenHelper, IRefreshTokenRepository refreshTokenRepository)
        {
            _userRepository = userRepository;
            _operationClaimRepository = operationClaimRepository;
            _tokenHelper = tokenHelper;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<CreateAccessTokenByRefreshTokenResponse> Handle(CreateAccessTokenByRefreshTokenRequest request, CancellationToken cancellationToken)
        {
            var existRefreshToken = await _refreshTokenRepository.GetAsync(x => x.Token == request.Token);
            if (existRefreshToken == null)
            {
                throw new Exception("Token Not Found");
            }
            var user = await _userRepository.GetAsync(u=>u.Id== existRefreshToken.UserId);
            if (user == null)
            {
                throw new Exception("User Not Found");
            }
            if (existRefreshToken.Expires < DateTime.Now)
            {
                throw new Exception("Refresh Token Expired");
            }
            var roles = await _operationClaimRepository.GetListAsync(x => x.UserOperationClaims.Any(y => y.UserId == user.Id));
            var accessToken = _tokenHelper.CreateToken(user, roles.Items);
            return new CreateAccessTokenByRefreshTokenResponse(
                        accessToken: accessToken.Token,
                        accessTokenExpiration: accessToken.Expiration
                    );
        }
    }
}
