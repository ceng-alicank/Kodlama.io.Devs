using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Users.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        public CreateUserCommandHandler(IUserRepository userRepository,IMapper mapper, ITokenHelper tokenHelper, IOperationClaimRepository operationClaimRepository, IRefreshTokenRepository refreshTokenRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenHelper = tokenHelper;
            _operationClaimRepository = operationClaimRepository;
            _refreshTokenRepository = refreshTokenRepository;   
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            byte[] passwordHash;
            byte[] passwordSalt;
            HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
            var user = _mapper.Map<User>(request);
            user.Status = true;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            var addedUser = await _userRepository.AddAsync(user);
            var roles = await _operationClaimRepository.GetListAsync(x => x.UserOperationClaims.Any(y => y.UserId == addedUser.Id));
            var accessToken = _tokenHelper.CreateToken(addedUser, roles.Items);
            var refreshToken = _tokenHelper.CreateRefreshToken(addedUser);
            RefreshToken addedRefreshToken = await _refreshTokenRepository.AddAsync(refreshToken);
            return new CreateUserCommandResponse(
                    accessToken:accessToken.Token,
                    accessTokenExpiration:accessToken.Expiration,
                    refreshToken:refreshToken.Token,
                    refreshTokenExpiration:refreshToken.Expires
                );
        }
    }
}
