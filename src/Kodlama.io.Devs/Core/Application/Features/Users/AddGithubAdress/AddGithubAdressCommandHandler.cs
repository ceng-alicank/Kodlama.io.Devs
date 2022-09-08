using Application.Services.Repositories;
using MediatR;

namespace Application.Features.Users.AddGithubAdress
{
    public class AddGithubAdressCommandHandler : IRequestHandler<AddGithubAdressCommandRequest, AddGithubAdressCommandResponse>
    {
        private readonly IUserRepository _userRepository;

        public AddGithubAdressCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<AddGithubAdressCommandResponse> Handle(AddGithubAdressCommandRequest request, CancellationToken cancellationToken)
        {
            var entity =  await _userRepository.GetAsync(u => u.Id == request.Id);
            if (entity != null)
            {
                entity.GithubAdress = request.GithubAdress;
                var updatedEntity =  await _userRepository.UpdateAsync(entity);
                return new AddGithubAdressCommandResponse
                    (updatedEntity.GithubAdress);
            }
            return null;
        }
    }
}
