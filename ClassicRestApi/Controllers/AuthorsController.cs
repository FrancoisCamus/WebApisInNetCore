﻿using Microsoft.AspNetCore.Mvc;
using Shared;

namespace ClassicRestApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/authors")]
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
            return new ObjectResult(blogService.GetSocialNetworkProfilesByAuthor(id));
        }
    }
}
