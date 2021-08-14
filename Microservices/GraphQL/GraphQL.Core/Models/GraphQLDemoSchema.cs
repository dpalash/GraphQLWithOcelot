using System;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Core.Models
{
    public class GraphQLDemoSchema : Schema
    {
        public GraphQLDemoSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<Query>();
        }
    }
}
