using ClassicRestApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ClassicRestApi.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookStoreContext _context;

        public BooksController(BookStoreContext context)
        {
            _context = context;

            if (_context.Books.Count() == 0)
            {
                foreach (Book book in DataSource.GetBooks())
                {
                    _context.Books.Add(book);
                }
                _context.SaveChanges();
            }
        }

        // GET api/books
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_context.Books);
        }

        // GET api/books/978-0-321-87758-1
        [HttpGet("{isbn}")]
        public ActionResult<string> Get(string isbn)
        {
            Book book = _context.Books.FirstOrDefault(c => c.ISBN == isbn);
            return Ok(book);
        }

        // POST api/books
        [HttpPost]
        public void Post([FromBody]Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        // PUT api/books/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
