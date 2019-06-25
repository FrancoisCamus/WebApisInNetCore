using GraphQL.Types;
using GraphQLApi.GraphQl.Types.Outputs;
using Shared;

namespace GraphQLApi.GraphQl
{
    public class BlogServiceQuery : ObjectGraphType
    {
        public BlogServiceQuery(IBlogService blogService)
        {
            FieldAsync<AuthorType>(
                name: "author",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: async context =>
                {
                    var id = context.GetArgument<int>("id");
                    return await blogService.GetAuthorByIdAsync(id);
                }
            );

            FieldAsync<ListGraphType<AuthorType>>(
                "authors",
                resolve: async context => await blogService.GetAllAuthorsAsync());
        }
    }
}
