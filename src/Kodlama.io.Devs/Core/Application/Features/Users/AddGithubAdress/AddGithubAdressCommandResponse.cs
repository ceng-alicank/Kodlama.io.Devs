namespace Application.Features.Users.AddGithubAdress
{
    public class AddGithubAdressCommandResponse
    {
        public string GithubAddress { get; set; }

        public AddGithubAdressCommandResponse(string githubAddress)
        {
            GithubAddress = githubAddress;
        }
    }
}
