using Framework.Core.Base.Api;
using Framework.Core.Base.GraphQL;
using GraphQL.Core.DTOs;
using GraphQL.Types;

namespace GraphQL.Core.Types
{
    public sealed class BlogPostType : ObjectGraphTypeBase<BlogPost>
    {
        public BlogPostType()
        {
            Name = "BlogPost";
            Field(_ => _.Id, type: typeof(IdGraphType)).Description("The Id of the Blog post.");
            Field(_ => _.Title).Description("The title of the blog post.");
            Field(_ => _.Content).Description("The content of the blog post.");
        }
    }
}
