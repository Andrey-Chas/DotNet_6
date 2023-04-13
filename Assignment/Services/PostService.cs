using Assignment.Data;
using Assignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Services
{
    public class PostService : IPostService
    {
        private readonly DbPosts context;
        private readonly IWebHostEnvironment hostEnvironment;

        public PostService(DbPosts context, IWebHostEnvironment hostEnvironment)
        {
            this.context = context;
            this.hostEnvironment = hostEnvironment;
        }
        public async Task AddPost(Post post)
        {
            string wwwRootPath = hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(post.Image.FileName);
            string extension = Path.GetExtension(post.Image.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await post.Image.CopyToAsync(fileStream);
            }

            post.DateAdded = DateTime.Now;
        }
    }
}
