using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.Users.Update
{
    public class UpdateGithubAddressCommandRequest : IRequest<UpdateGithubAddressCommandResponse> ,ISecuredRequest
    {
        public int Id { get; set; }
        public string GithubAddress { get; set; }
        public string[] Roles { get; set; }

    }
}