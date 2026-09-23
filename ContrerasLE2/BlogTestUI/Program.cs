using BlogDataLibrary;
using BlogDataLibrary.Models;

namespace BlogTestUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Blog Test UI");
            Console.WriteLine("------------");

            var post = new PostModel
            {
                UserId = 1,
                Title = "My First Post",
                Body = "Hello! This is my first blog post.",
                DateCreated = DateTime.Now
            };

            int rows = PostData.CreatePost(post);

            Console.WriteLine($"Posts created: {rows}");

            Console.ReadLine();
        }
    }
}       