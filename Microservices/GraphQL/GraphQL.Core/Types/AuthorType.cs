using Framework.Core.Base.Api;
using Framework.Core.Base.GraphQL;
using GraphQL.Core.DTOs;

namespace GraphQL.Core.Types
{
    public sealed class AuthorType : ObjectGraphTypeBase<Author>
    {
        public AuthorType()
        {
            Name = "Author";
            Field(_ => _.Id).Description("Author's Id.");
            Field(_ => _.FirstName).Description("First name of the author");
            Field(_ => _.LastName).Description("Last name of the author");
        }
    }
}
