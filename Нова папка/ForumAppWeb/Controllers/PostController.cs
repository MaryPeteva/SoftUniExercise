using ForumApp.Core.Contracts;
using ForumApp.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForumAppWeb.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        // GET: PostController
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            IEnumerable<PostModel> posts = await _postService.GetAllPostsAsync();
            return View(posts);
        }


        [HttpGet]
        public IActionResult Add() 
        {
            var post = new PostModel();
            return View(post);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostModel post) 
        {
            if (!ModelState.IsValid) 
            {
                return View(post);
            }

            await _postService.AddPostAsync(post);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id) 
        {
            var post = await _postService.GetByIdAsync(id);
            return View(post);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostModel post, int id) 
        {
            if (!ModelState.IsValid) 
            {
                return View(post);
            }

            await _postService.UpdatePostAsync(post);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id) 
        {
            await _postService.DeletePosttAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
