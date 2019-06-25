using GraphQL.Types;
using Shared;
using Shared.Entities;

namespace GraphQLApi.GraphQl.Types.Outputs
{
    public class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType(IBlogService blogService)
        {
            Field(x => x.Id).Description("Id of an author");
            Field(x => x.Name).Description("Name of an author");
            Field(x => x.Bio).Description("Bio description of an author");

            FieldAsync<ListGraphType<PostType>>(
                name: "posts",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: async context =>
                {
                    return await blogService.GetPostsByAuthorAsync(context.Source.Id);
                }
            );

            FieldAsync<ListGraphType<SocialNetworkProfileType>>(
                name: "socials",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: async context =>
                {
                    return await blogService.GetSocialNetworkProfilesByAuthorAsync(context.Source.Id);
                }
            );
        }
    }
}
