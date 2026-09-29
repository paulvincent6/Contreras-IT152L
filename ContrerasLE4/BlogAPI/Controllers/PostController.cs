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
    }
}