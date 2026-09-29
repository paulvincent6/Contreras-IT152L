using BlogDataLibrary.Data;
using BlogDataLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly ISqlData _db;

        public PostController(ISqlData db)
        {
            _db = db;
        }

        [HttpGet]
        public List<ListPostModel> GetPosts()
        {
            return _db.ListPosts();
        }

        [HttpGet("{id}")]
        public ListPostModel GetPost(int id)
        {
            return _db.ShowPostDetails(id);
        }

        private int GetCurrentUserId()
        {
            var userId = User.Claims
                .FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?
                .Value;

            return int.Parse(userId);
        }

        [HttpPost]
        public IActionResult AddPost(PostForm post)
        {
            var newPost = new PostModel
            {
                UserId = GetCurrentUserId(),
                Title = post.Title,
                Body = post.Body,
                DateCreated = DateTime.Now
            };

            _db.AddPost(newPost);

            return Ok();
        }
    }
}