using Microsoft.AspNetCore.Mvc;
using Shared;
using System.Threading.Tasks;

namespace ClassicRestApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IBlogService blogService;

        public AuthorsController(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return new ObjectResult(await blogService.GetAllAuthorsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorByIdAsync(int id)
        {
            return new ObjectResult(await blogService.GetAuthorByIdAsync(id));
        }

        [HttpGet("{id}/posts")]
        public async Task<IActionResult> GetPostsByAuthorAsync(int id)
        {
            return new ObjectResult(await blogService.GetPostsByAuthorAsync(id));
        }

        [HttpGet("{id}/socials")]
        public async Task<IActionResult> GetSocialsByAuthorAsync(int id)
        {
            return new ObjectResult(await blogService.GetSocialNetworkProfilesByAuthorAsync(id));
        }
    }
}
