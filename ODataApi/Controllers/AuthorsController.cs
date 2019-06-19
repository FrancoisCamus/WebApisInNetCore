using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.Entities;
using System.Linq;

namespace ODataApi.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ODataController
    {
        private SharedDbContext _context;

        public AuthorsController(SharedDbContext context)
        {
            _context = context;
            _context.Populate();
        }

        [EnableQuery]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Authors);
        }

        [EnableQuery]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_context.Authors.FirstOrDefault(c => c.Id == id));
        }

        [EnableQuery]
        [HttpPost]
        public IActionResult Post([FromBody]Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
            return Created(author);
        }
    }
}
