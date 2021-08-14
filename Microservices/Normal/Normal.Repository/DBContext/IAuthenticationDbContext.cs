using MicroOrm.Dapper.Repositories;
using MicroOrm.Dapper.Repositories.DbContext;
using Normal.Core.Entities;

namespace Normal.Repository.DBContext
{
    public interface IAuthenticationDbContext : IDapperDbContext
    {
        IDapperRepository<FileContent> FileContent { get; }
    }
}
