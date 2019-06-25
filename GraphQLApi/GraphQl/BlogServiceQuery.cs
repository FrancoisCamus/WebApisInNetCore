using GraphQL.Types;
using GraphQLApi.GraphQl.Types.Outputs;
using Shared;

namespace GraphQLApi.GraphQl
{
    public class BlogServiceQuery : ObjectGraphType
    {
        public BlogServiceQuery(IBlogService blogService)
        {
            Field<AuthorType>(
                name: "author",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return blogService.GetAuthorById(id);
                }
            );

            Field<ListGraphType<AuthorType>>(
                "authors",
                resolve: context => blogService.GetAllAuthors());
        }
    }
}
