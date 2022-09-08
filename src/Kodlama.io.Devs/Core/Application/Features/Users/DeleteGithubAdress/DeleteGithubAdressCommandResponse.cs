namespace Application.Features.Users.DeleteGithubAdress
{
    public class DeleteGithubAdressCommandResponse
    {
        public bool IsDeleted { get; set; }

        public DeleteGithubAdressCommandResponse(bool ısDeleted)
        {
            IsDeleted = ısDeleted;
        }
    }
}
