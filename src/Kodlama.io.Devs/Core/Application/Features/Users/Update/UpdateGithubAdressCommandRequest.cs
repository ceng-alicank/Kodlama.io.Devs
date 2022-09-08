using MediatR;

namespace Application.Features.Users.Update
{
    public class UpdateGithubAdressCommandRequest : IRequest<UpdateGithubAdressCommandResponse>
    {
        public int Id { get; set; }
        public string GithubAdress { get; set; }
    }
}