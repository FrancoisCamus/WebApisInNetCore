using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.Entities;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace ODataApi.Controllers
{
    [ApiVersion("1.0")]
    [ODataRoutePrefix("Authors")]
    public class AuthorsController : ODataController
    {
        private SharedDbContext _context;

        public AuthorsController(SharedDbContext context)
        {
            _context = context;
            _context.Populate();
        }

        [ODataRoute()]
        // Does not work: See global setup in Startup.
        //[EnableQuery(MaxTop = 100, AllowedQueryOptions = Select | Expand | Filter | OrderBy | Top | Skip | Count)]
        [EnableQuery]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<Author>), Status200OK)]
        public IActionResult GetAll()
        {
            return Ok(_context.Authors);
        }

        [ODataRoute("({id})")]
        [EnableQuery]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Author), Status200OK)]
        public IActionResult GetById(int id)
        {
            return Ok(_context.Authors.FirstOrDefault(c => c.Id == id));
        }

        [ODataRoute]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Author), Status201Created)]
        public IActionResult Add([FromBody]Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
            return Created(author);
        }
    }
}
