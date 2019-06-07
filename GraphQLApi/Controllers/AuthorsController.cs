using GraphQLApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly BlogService blogService;
        public AuthorsController(BlogService blogService)
        {
            this.blogService = blogService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return new ObjectResult(blogService.GetAllAuthors());
        }
        [HttpGet("{id}")]
        public IActionResult GetAuthorById(int id)
        {
            return new ObjectResult(blogService.GetAuthorById(id));
        }
        [HttpGet("{id}/posts")]
        public IActionResult GetPostsByAuthor(int id)
        {
            return new ObjectResult(blogService.GetPostsByAuthor(id));
        }
        [HttpGet("{id}/socials")]
        public IActionResult GetSocialsByAuthor(int id)
        {
            return new ObjectResult(blogService.GetSNsByAuthor(id));
        }
    }
}
