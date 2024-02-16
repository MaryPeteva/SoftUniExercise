using ForumApp.Core.Models;

namespace ForumApp.Core.Contracts
{
    public interface IPostService
    {
        Task AddPostAsync(PostModel post);
        Task DeletePosttAsync(int id);
        Task<IEnumerable<PostModel>> GetAllPostsAsync();
        Task<PostModel> GetByIdAsync(int id);
        Task UpdatePostAsync(PostModel post);
        
    }
}
