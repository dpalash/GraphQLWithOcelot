namespace Normal.Core.Interfaces.Repositories
{
    public interface IAuthenticationManagementRepository
    {
        IFileContentRepository FileContentRepository { get; }
    }
}