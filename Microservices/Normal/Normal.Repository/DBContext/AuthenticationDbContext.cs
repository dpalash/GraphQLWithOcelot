using System.Data.SqlClient;
using MicroOrm.Dapper.Repositories;
using MicroOrm.Dapper.Repositories.DbContext;
using Microsoft.Extensions.Configuration;
using Normal.Core.Entities;

namespace Normal.Repository.DBContext
{
    public class AuthenticationDbContext : DapperDbContext, IAuthenticationDbContext
    {
        private IDapperRepository<FileContent> _fileContent;

        public AuthenticationDbContext(IConfiguration configuration) : base(new SqlConnection(configuration["ConnectionStrings:DefaultConnection"]))
        {

        }

        public IDapperRepository<FileContent> FileContent => _fileContent ??= new DapperRepository<FileContent>(Connection);
    }
}
