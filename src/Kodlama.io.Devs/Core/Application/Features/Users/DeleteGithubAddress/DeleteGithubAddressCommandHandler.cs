using Application.Services.Repositories;
using MediatR;

namespace Application.Features.Users.DeleteGithubAddress
{
    public class DeleteGithubAddressCommandHandler : IRequestHandler<DeleteGithubAddressCommandRequest, DeleteGithubAddressCommandResponse>
    {
        private readonly IUserRepository _userRepository;

        public DeleteGithubAddressCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<DeleteGithubAddressCommandResponse> Handle(DeleteGithubAddressCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(u => u.Id == request.Id);
            if (user!=null)
            {
                user.GithubAddress = null;
                await _userRepository.UpdateAsync(user);
                return new DeleteGithubAddressCommandResponse(true);
            }
            return new DeleteGithubAddressCommandResponse(false);
        }
    }
}
