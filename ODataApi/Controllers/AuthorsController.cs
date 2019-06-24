using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace ODataApi.Controllers
{
    [ApiVersion("1.0")]
    [ODataRoutePrefix("Authors")]
    public class AuthorsController : ODataController
    {
        private IBlogService blogService;

        public AuthorsController(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        [ODataRoute()]
        // Does not work: See global setup in Startup.
        //[EnableQuery(MaxTop = 100, AllowedQueryOptions = Select | Expand | Filter | OrderBy | Top | Skip | Count)]
        [EnableQuery]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<Author>), Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await this.blogService.GetAllAuthorsAsync());
        }

        [ODataRoute("({id})")]
        [EnableQuery]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Author), Status200OK)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await this.blogService.GetAuthorByIdAsync(id));
        }

        [ODataRoute]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Author), Status201Created)]
        public async Task<IActionResult> AddAsync([FromBody]Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Author added = await this.blogService.AddAuthorAsync(author);

            return Created(added);
        }
    }
}
