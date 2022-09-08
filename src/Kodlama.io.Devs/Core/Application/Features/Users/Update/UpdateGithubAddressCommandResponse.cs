namespace Application.Features.Users.Update
{
    public class UpdateGithubAddressCommandResponse
    {
        public string GithubAddress { get; set; }

        public UpdateGithubAddressCommandResponse(string githubAddress)
        {
            GithubAddress = githubAddress;
        }
    }
}