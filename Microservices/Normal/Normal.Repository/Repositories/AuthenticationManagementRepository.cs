using Normal.Core.Interfaces.Repositories;
using Normal.Repository.DBContext;

namespace Normal.Repository.Repositories
{
    public class AuthenticationManagementRepository : IAuthenticationManagementRepository
    {
        private readonly AuthenticationDbContext _flightActionDbContext;

        private FileContentRepository _fileContentRepository;

        public AuthenticationManagementRepository(AuthenticationDbContext flightActionDbContext)
        {
            _flightActionDbContext = flightActionDbContext;
        }

        public IFileContentRepository FileContentRepository => _fileContentRepository ??= new FileContentRepository(_flightActionDbContext);
    }
}
