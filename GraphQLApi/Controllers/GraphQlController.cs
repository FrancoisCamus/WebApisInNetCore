using GraphQL;
using GraphQL.Types;
using GraphQLApi.Queries;
using Microsoft.AspNetCore.Mvc;
using Shared;
using System.Threading.Tasks;

namespace GraphQLApi.Controllers
{
    [Route(Startup.GraphQlPath)]
    public class GraphQlController : Controller
    {
        private readonly BlogService blogService;

        public GraphQlController(BlogService blogService)
        {
            this.blogService = blogService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQlQuery query)
        {
            var schema = new Schema { Query = new AuthorQuery(blogService) };
            var result = await new DocumentExecuter().ExecuteAsync(x =>
            {
                x.Schema = schema;
                x.Query = query.Query;
                x.Inputs = query.Variables;
            });
            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
