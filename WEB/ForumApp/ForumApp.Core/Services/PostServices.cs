using ForumApp.Core.Contracts;
using ForumApp.Core.Models;
using ForumApp.Infrastructure.Data;
using ForumApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using static ForumApp.Infrastructure.Constants.ErrorMessages;

namespace ForumApp.Core.Services
{
    public class PostServices : IPostService
    {
        private readonly ForumAppDbContext context;

        public PostServices(ForumAppDbContext _context)
        {
            context = _context;
        }

        public async Task AddPostAsync(PostModel post)
        {
            var newPost = new Post()
            {
                Title = post.Title,
                Content = post.Content,
            };
            await context.Posts.AddAsync(newPost);
            await context.SaveChangesAsync();
        }

        public async Task DeletePosttAsync(int id)
        {
            var post = await context.Posts.FindAsync(id);
            if (post != null)
            {
                throw new ArgumentException(invalidPost);
            }

            context.Posts.Remove(post);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PostModel>> GetAllPostsAsync()
        {
            return await context.Posts
                .Select(p => new PostModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                })
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<PostModel> GetByIdAsync(int id)
        {
            var post = await context.Posts.FindAsync(id);

            if (post == null)
            {
                throw new ArgumentException(invalidPost);
            }

            return new PostModel()
            {
                Id = id,
                Title = post.Title,
                Content = post.Content,
            };
        }

        public async Task UpdatePostAsync(PostModel post)
        {
            var postToUpdate = await context.Posts.FindAsync(post.Id);

            if (postToUpdate == null)
            {
                throw new ArgumentException(invalidPost);
            }
            postToUpdate.Content = postToUpdate.Content;
            postToUpdate.Title = postToUpdate.Content;
            await context.SaveChangesAsync();
        }

    }
}