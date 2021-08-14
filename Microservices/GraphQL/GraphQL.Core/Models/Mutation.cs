using Framework.Core.Base.GraphQL;
using GraphQL.Core.DTOs;
using GraphQL.Core.InputType;
using GraphQL.Core.Interfaces.Services;
using GraphQL.Core.Types;
using GraphQL.Types;

namespace GraphQL.Core.Models
{
    public class ProMutation : ObjectGraphTypeBase<object>
    {
        public ProMutation(IAuthorService authorService)
        {
            Name = "Mutation";

            Field<AuthorType>(
                "createAuthor",
                arguments: new QueryArguments(new QueryArgument<InputObjectGraphType<AuthorInputType>> { Name = "author" }),
                resolve: context =>
                {
                    var author = context.GetArgument<Author>("author");
                    return authorService.Add(author);
                }
            );
        }
    }
}
