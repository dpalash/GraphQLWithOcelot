using Framework.Core.Base.GraphQL;
using GraphQL.Core.Interfaces.Services;
using GraphQL.Core.Types;
using GraphQL.Types;

namespace GraphQL.Core.Models
{
    public class Query : ObjectGraphQueryBase
    {
        public Query(IAuthorService authorService)
        {
            int id = 0;

            Field<ListGraphType<AuthorType>>(
                name: "authors", resolve: context => authorService.GetAllAuthors());

            Field<AuthorType>(
                name: "author",
                arguments: new QueryArguments(new
                    QueryArgument<IntGraphType>
                { Name = "id" }),
                resolve: context =>
                {
                    id = context.GetArgument<int>("id");
                    return authorService.GetAuthorById(id);
                }
            );

            Field<ListGraphType<BlogPostType>>(
                name: "blogs",
                arguments: new QueryArguments(new
                    QueryArgument<IntGraphType>
                { Name = "id" }),
                resolve: context => authorService.GetPostsByAuthor(id));
        }
    }
}
