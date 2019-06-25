using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GraphQLApi.Controllers
{
    [Route(Startup.GraphQlPath)]
    public class GraphQlController : Controller
    {
        private readonly ISchema schema;
        private readonly IDocumentExecuter documentExecuter;

        public GraphQlController(ISchema schema, IDocumentExecuter documentExecuter)
        {
            this.schema = schema;
            this.documentExecuter = documentExecuter;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQlQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            Inputs inputs = query.Variables.ToInputs();
            var executionOptions = new ExecutionOptions
            {
                Schema = this.schema,
                Query = query.Query,
                Inputs = inputs
            };

            ExecutionResult result = await this.documentExecuter
                .ExecuteAsync(executionOptions)
                .ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
