using BlogDataLibrary;
using BlogDataLibrary.Database;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace BlogTestUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Load appsettings.json
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Create the database connection service
            ISqlDataAccess db = new SqlDataAccess(config);

            // Inject the database service into PostData
            PostData postData = new PostData(db);

            Console.WriteLine("Blog Test UI");
            Console.WriteLine("------------");

            // Get all posts
            var posts = postData.GetAllPosts();

            foreach (var post in posts)
            {
                Console.WriteLine($"ID: {post.Id}");
                Console.WriteLine($"Title: {post.Title}");
                Console.WriteLine($"Author: {post.UserName}");
                Console.WriteLine($"Body: {post.Body}");
                Console.WriteLine($"Date: {post.DateCreated}");
                Console.WriteLine("----------------------------");
            }

            Console.ReadLine();
        }
    }
}