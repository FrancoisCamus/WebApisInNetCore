using GraphQL.Types;
using GraphQLApi.GraphQl.Types.Inputs;
using GraphQLApi.GraphQl.Types.Outputs;
using Shared;
using Shared.Entities;

namespace GraphQLApi.GraphQl
{
    public class BlogServiceMutation : ObjectGraphType
    {
        public BlogServiceMutation(IBlogService blogService)
        {
            Field<AuthorType>(
                "createAuthor",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<AuthorInputType>> { Name = "author" }
                ),
                resolve: context =>
                {
                    var author = context.GetArgument<Author>("author");
                    return blogService.AddAuthor(author);
                });
        }
    }
}
