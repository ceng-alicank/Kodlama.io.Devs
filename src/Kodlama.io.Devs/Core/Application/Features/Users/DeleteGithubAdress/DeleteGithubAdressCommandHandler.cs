using Application.Services.Repositories;
using MediatR;

namespace Application.Features.Users.DeleteGithubAdress
{
    public class DeleteGithubAdressCommandHandler : IRequestHandler<DeleteGithubAdressCommandRequest, DeleteGithubAdressCommandResponse>
    {
        private readonly IUserRepository _userRepository;

        public DeleteGithubAdressCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<DeleteGithubAdressCommandResponse> Handle(DeleteGithubAdressCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(u => u.Id == request.Id);
            if (user!=null)
            {
                user.GithubAdress = null;
                await _userRepository.UpdateAsync(user);
                return new DeleteGithubAdressCommandResponse(true);
            }
            return new DeleteGithubAdressCommandResponse(false);
        }
    }
}
