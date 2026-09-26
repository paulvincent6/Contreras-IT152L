using BlogDataLibrary.Database;
using BlogDataLibrary.Models;
using System.Collections.Generic;
using System.Linq;

namespace BlogDataLibrary
{
    public class PostData
    {
        private readonly ISqlDataAccess _db;

        public PostData(ISqlDataAccess db)
        {
            _db = db;
        }

        public PostModel? GetPostById(int id)
        {
            string sql = @"SELECT Id, UserId, Title, Body, DateCreated
                           FROM dbo.Posts
                           WHERE Id = @Id;";

            var parameters = new { Id = id };

            var posts = _db.LoadData<PostModel, dynamic>(
                sql,
                parameters,
                "Default",
                false);

            return posts.FirstOrDefault();
        }

        public int CreatePost(PostModel post)
        {
            string sql = @"INSERT INTO dbo.Posts
                           (UserId, Title, Body, DateCreated)
                           VALUES
                           (@UserId, @Title, @Body, @DateCreated);";

            _db.SaveData(
                sql,
                post,
                "Default",
                false);

            return 1;
        }

        public int UpdatePost(PostModel post)
        {
            string sql = @"UPDATE dbo.Posts
                           SET UserId = @UserId,
                               Title = @Title,
                               Body = @Body,
                               DateCreated = @DateCreated
                           WHERE Id = @Id;";

            _db.SaveData(
                sql,
                post,
                "Default",
                false);

            return 1;
        }

        public int DeletePost(int id)
        {
            string sql = @"DELETE FROM dbo.Posts
                           WHERE Id = @Id;";

            var parameters = new { Id = id };

            _db.SaveData(
                sql,
                parameters,
                "Default",
                false);

            return 1;
        }

        public List<ListPostModel> GetAllPosts()
        {
            string sql = @"SELECT p.Id,
                                  p.Title,
                                  p.Body,
                                  p.DateCreated,
                                  u.UserName
                           FROM dbo.Posts p
                           INNER JOIN dbo.Users u
                               ON p.UserId = u.Id
                           ORDER BY p.DateCreated DESC;";

            return _db.LoadData<ListPostModel, dynamic>(
                sql,
                new { },
                "Default",
                false);
        }
    }
}