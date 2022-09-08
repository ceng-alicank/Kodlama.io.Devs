namespace Application.Features.Users.DeleteGithubAddress
{
    public class DeleteGithubAddressCommandResponse
    {
        public bool IsDeleted { get; set; }

        public DeleteGithubAddressCommandResponse(bool ısDeleted)
        {
            IsDeleted = ısDeleted;
        }
    }
}
