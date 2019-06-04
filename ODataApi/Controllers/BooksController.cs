using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using ODataApi.Models;
using System.Linq;

namespace ODataApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ODataController
    {
        private BookStoreContext _db;

        public BooksController(BookStoreContext context)
        {
            _db = context;
            if (context.Books.Count() == 0)
            {
                foreach (var b in DataSource.GetBooks())
                {
                    context.Books.Add(b);
                    context.Presses.Add(b.Press);
                }
                context.SaveChanges();
            }
        }

        [EnableQuery]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_db.Books);
        }

        [EnableQuery]
        [HttpGet("{key}")]
        public IActionResult Get(int key)
        {
            return Ok(_db.Books.FirstOrDefault(c => c.Id == key));
        }

        [EnableQuery]
        [HttpPost]
        public IActionResult Post([FromBody]Book book)
        {
            _db.Books.Add(book);
            _db.SaveChanges();
            return Created(book);
        }
    }
}
