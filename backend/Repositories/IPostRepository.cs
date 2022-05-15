using backend.Models;

namespace backend.Repositories
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> Get();
        Task<Post?> Get(int id);
        Task<Post> Create(Post post);
        Task Update(Post post);
        Task Delete(int id);
    }
}
