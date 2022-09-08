namespace Application.Features.Users.AddGithubAddress
{
    public class AddGithubAddressCommandResponse
    {
        public string GithubAddress { get; set; }

        public AddGithubAddressCommandResponse(string githubAddress)
        {
            GithubAddress = githubAddress;
        }
    }
}
