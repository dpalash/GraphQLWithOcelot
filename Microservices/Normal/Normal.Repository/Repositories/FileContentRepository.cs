using Normal.Repository.DBContext;
using MicroOrm.Dapper.Repositories;
using Normal.Core.Interfaces.Repositories;
using Normal.Core.Entities;

namespace Normal.Repository.Repositories
{
    public class FileContentRepository : DapperRepository<FileContent>, IFileContentRepository
    {
        private readonly AuthenticationDbContext _authenticationDbContext;

        public FileContentRepository(AuthenticationDbContext authenticationDbContext) : base(authenticationDbContext.Connection)
        {
            _authenticationDbContext = authenticationDbContext;
        }
    }
}
