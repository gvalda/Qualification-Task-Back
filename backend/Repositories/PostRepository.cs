using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class PostRepository : IPostRepository
    {
         private readonly PostContext _context;

        public PostRepository(PostContext context)
        {
            _context = context;
        }

        public async Task<Post> Create(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return post;
        }

        public async Task Delete(int id)
        {
            var postToDelete = await _context.Posts.FindAsync(id);
            if(postToDelete != null)
            {
                _context.Posts.Remove(postToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Post>> Get()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<Post?> Get(int id)
        {
            return await _context.Posts.FindAsync(id);
        }

        public async Task Update(Post post)
        {
            _context.Entry(post).State = EntityState.Modified;
            await _context.AddRangeAsync();
        }
    }
}
