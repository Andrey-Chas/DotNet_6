using Assignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Services
{
    public interface IPostService
    {
        Task AddPost(Post post);
    }
}
