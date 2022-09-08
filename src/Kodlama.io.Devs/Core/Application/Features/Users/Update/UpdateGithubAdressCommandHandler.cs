using Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Update
{
    public class UpdateGithubAdressCommandHandler : IRequestHandler<UpdateGithubAdressCommandRequest, UpdateGithubAdressCommandResponse>
    {
        private readonly IUserRepository _userRepository;

        public UpdateGithubAdressCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UpdateGithubAdressCommandResponse> Handle(UpdateGithubAdressCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(u => u.Id == request.Id);
            if (user != null)
            {
                user.GithubAdress = request.GithubAdress;
                var updatedUser  =await _userRepository.UpdateAsync(user);
                return new UpdateGithubAdressCommandResponse(updatedUser.GithubAdress);
            }
            return null;
        }
    }
}
