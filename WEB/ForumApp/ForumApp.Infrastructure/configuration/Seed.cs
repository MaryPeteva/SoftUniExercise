using ForumApp.Infrastructure.Data;
using ForumApp.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Infrastructure.configuration
{
    public class ForumAppDbSeeder
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ForumAppDbContext _context;

        public ForumAppDbSeeder(UserManager<IdentityUser> userManager, ForumAppDbContext forumAppDbContext)
        {
            _userManager = userManager;
            _context = forumAppDbContext;
        }

        public async Task SeedUsersAsync(List<(string UserName, string Email, string Password)> users)
        {
            foreach (var user in users)
            {
                var newUser = new IdentityUser
                {
                    UserName = user.UserName,
                    Email = user.Email,

                    
                };

                // Create the user
                var result = await _userManager.CreateAsync(newUser, user.Password);

                if (result.Succeeded)
                {
                    // Generate and set the email confirmation token
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
                    // Confirm the user's email
                    await _userManager.ConfirmEmailAsync(newUser, token);
                    // Set lockout status to false
                    await _userManager.SetLockoutEnabledAsync(newUser, false);
                }
                else
                {
                    // Handle user creation failure
                    // For example, log errors or handle the failure in some other way
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine($"Error: {error.Description}");
                    }
                }
            }
        }


        public async Task<Post[]> SeedData()
        {
            try
            {
                var posts = new List<Post>
        {
            new Post { Title = "Best Practices for Exception Handling in C#", Content = "Exception handling is an essential aspect of writing robust and reliable C# code. In this post, we'll explore some of the best practices and techniques for handling exceptions effectively."},
            new Post { Title = "Intro to Object-Oriented Programming Concepts", Content = "Object-oriented programming (OOP) is a fundamental paradigm in modern software development. This post provides a comprehensive introduction to key OOP concepts such as encapsulation, inheritance, and polymorphism."},
            new Post { Title = "Benefits of Functional Programming in JavaScript", Content = "Functional programming has gained popularity in recent years due to its emphasis on immutability and declarative style. This post discusses the benefits of using functional programming techniques in JavaScript development."},
            new Post { Title = "Getting Started with Python: A Beginner's Guide", Content = "Python is a versatile and beginner-friendly programming language. This post offers a step-by-step guide for beginners looking to learn Python, covering topics such as syntax, data types, and control structures."},
        };

                // Get a list of all user IDs from the database
                var users = await _userManager.Users.ToListAsync();
                var userIds = users.Select(u => u.Id).ToList();

                // Assign a random user ID to each post
                var random = new Random();
                foreach (var post in posts)
                {
                    post.PosterId = userIds[random.Next(userIds.Count)];
                }

                // Add posts to the context and save changes
                await _context.Posts.AddRangeAsync(posts);
                await _context.SaveChangesAsync();

                return posts.ToArray();
            }
            catch (Exception ex)
            {
                // Log any exceptions
                Console.WriteLine($"An error occurred while seeding posts: {ex.Message}");
                throw; // Rethrow the exception to indicate seeding failure
            }
        }

    }
}
