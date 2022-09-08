using Application.Services.Repositories;
using MediatR;

namespace Application.Features.Users.AddGithubAddress
{
    public class AddGithubAddressCommandHandler : IRequestHandler<AddGithubAddressCommandRequest, AddGithubAddressCommandResponse>
    {
        private readonly IUserRepository _userRepository;

        public AddGithubAddressCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<AddGithubAddressCommandResponse> Handle(AddGithubAddressCommandRequest request, CancellationToken cancellationToken)
        {
            var entity =  await _userRepository.GetAsync(u => u.Id == request.Id);
            if (entity != null)
            {
                entity.GithubAddress = request.GithubAddress;
                var updatedEntity =  await _userRepository.UpdateAsync(entity);
                return new AddGithubAddressCommandResponse
                    (updatedEntity.GithubAddress);
            }
            return null;
        }
    }
}
