using Framework.Core.Base.Api;
using Framework.Core.Base.GraphQL;
using GraphQL.Core.DTOs;
using GraphQL.Types;

namespace GraphQL.Core.InputType
{
    public sealed class AuthorInputType : ObjectGraphTypeBase
    {
        public AuthorInputType()
        {
            Name = "AuthorInput";

            Field<NonNullGraphType<StringGraphType>>("firstName");
            Field<NonNullGraphType<StringGraphType>>("lastName");
        }
    }
}
