using BlogDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDataLibrary
{
    public class PostData
    {
        public static PostModel? GetPostById(int id)
        {
            string sql = @"SELECT Id, UserId, Title, Body, DateCreated
                   FROM dbo.Posts
                   WHERE Id = @Id;";

            var parameters = new { Id = id };

            var posts = SqlDataAccess.LoadData<PostModel, dynamic>(
                sql,
                parameters);

            return posts.FirstOrDefault();
        }

        public static int CreatePost(PostModel post)
        {
            string sql = @"INSERT INTO dbo.Posts
                   (UserId, Title, Body, DateCreated)
                   VALUES
                   (@UserId, @Title, @Body, @DateCreated);";

            return SqlDataAccess.SaveData(sql, post);
        }

        public static int UpdatePost(PostModel post)
        {
            string sql = @"UPDATE dbo.Posts
                   SET UserId = @UserId,
                       Title = @Title,
                       Body = @Body,
                       DateCreated = @DateCreated
                   WHERE Id = @Id;";

            return SqlDataAccess.SaveData(sql, post);
        }

        public static int DeletePost(int id)
        {
            string sql = @"DELETE FROM dbo.Posts
                   WHERE Id = @Id;";

            var parameters = new { Id = id };

            return SqlDataAccess.SaveData(sql, parameters);
        }

        public static List<ListPostModel> GetAllPosts()
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

            return SqlDataAccess.LoadData<ListPostModel, dynamic>(
                sql,
                new { });
        }
    }
}
