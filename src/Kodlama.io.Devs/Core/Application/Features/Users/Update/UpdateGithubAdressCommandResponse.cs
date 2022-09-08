namespace Application.Features.Users.Update
{
    public class UpdateGithubAdressCommandResponse
    {
        public string GithubAdress { get; set; }

        public UpdateGithubAdressCommandResponse(string githubAdress)
        {
            GithubAdress = githubAdress;
        }
    }
}