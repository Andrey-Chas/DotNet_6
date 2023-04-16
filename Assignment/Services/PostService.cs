using Assignment.Data;
using Assignment.Models;
using Assignment.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

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
            post.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/images/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await post.Image.CopyToAsync(fileStream);
            }

            post.DateAdded = DateTime.Now;
            context.Add(post);
            await context.SaveChangesAsync();
        }

        public async Task DeletePost(int id)
        {
            var post = await context.Post.FindAsync(id);

            if (post != null)
            {
                var imagePath = Path.Combine(hostEnvironment.WebRootPath, "images", post.ImageName);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }

                context.Post.Remove(post);
            }

            await context.SaveChangesAsync();
        }

        public async Task EditPost(Post post)
        {
            string wwwRootPath = hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(post.Image.FileName);
            string extension = Path.GetExtension(post.Image.FileName);
            post.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/images/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await post.Image.CopyToAsync(fileStream);
            }

            post.DateAdded = DateTime.Now;
            context.Update(post);
            await context.SaveChangesAsync();
        }
    }
}
