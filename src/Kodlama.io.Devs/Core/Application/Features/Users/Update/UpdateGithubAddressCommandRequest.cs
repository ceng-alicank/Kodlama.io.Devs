using MediatR;

namespace Application.Features.Users.Update
{
    public class UpdateGithubAddressCommandRequest : IRequest<UpdateGithubAddressCommandResponse>
    {
        public int Id { get; set; }
        public string GithubAddress { get; set; }
    }
}