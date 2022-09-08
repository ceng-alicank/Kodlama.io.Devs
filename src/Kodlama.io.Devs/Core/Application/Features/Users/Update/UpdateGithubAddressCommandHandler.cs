using Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Update
{
    public class UpdateGithubAddressCommandHandler : IRequestHandler<UpdateGithubAddressCommandRequest, UpdateGithubAddressCommandResponse>
    {
        private readonly IUserRepository _userRepository;

        public UpdateGithubAddressCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UpdateGithubAddressCommandResponse> Handle(UpdateGithubAddressCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(u => u.Id == request.Id);
            if (user != null)
            {
                user.GithubAddress = request.GithubAddress;
                var updatedUser  =await _userRepository.UpdateAsync(user);
                return new UpdateGithubAddressCommandResponse(updatedUser.GithubAddress);
            }
            return null;
        }
    }
}
