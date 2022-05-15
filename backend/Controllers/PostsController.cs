using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;
using backend.Repositories;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository _postRepository;

        public PostsController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        // GET: api/Posts
        [HttpGet]
        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await _postRepository.Get();
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post?>> GetPost(int id)
        {
            return await _postRepository.Get(id);
        }

        // PUT: api/Posts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, Post post)
        {
            if(id != post.Id)
            {
                return BadRequest();
            }

            await _postRepository.Update(post);

            return NoContent();
        }

        // POST: api/Posts
        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(Post post)
        {
            var newPost = await _postRepository.Create(post);
            return CreatedAtAction(nameof(GetPosts), new { id = newPost.Id });
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var postToDelete = await _postRepository.Get(id);
            if (postToDelete == null)
                return NotFound();

            await _postRepository.Delete(postToDelete.Id);
            return NoContent();
        }
    }
}
