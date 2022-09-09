using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Users.Login
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly ITokenHelper _tokenHelper;


        public LoginUserCommandHandler(IUserRepository userRepository, IMapper mapper, ITokenHelper tokenHelper, IOperationClaimRepository operationClaimRepository, IRefreshTokenRepository refreshTokenRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenHelper = tokenHelper;
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var usertocheck = await _userRepository.GetAsync(u => u.Email == request.Email);
            if (usertocheck != null)
            {
                if (HashingHelper.VerifyPasswordHash(request.Password, usertocheck.PasswordHash, usertocheck.PasswordSalt))
                {
                    var roles = await _operationClaimRepository.GetListAsync(x => x.UserOperationClaims.Any(y => y.UserId == usertocheck.Id));

                    AccessToken accessToken = _tokenHelper.CreateToken(usertocheck, roles.Items);
                    return _mapper.Map<LoginUserCommandResponse>(accessToken);
                }
            }
            return null;
        }
    }
}
