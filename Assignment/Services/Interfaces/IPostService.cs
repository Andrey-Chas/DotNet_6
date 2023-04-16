using Assignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Services.Interfaces
{
    public interface IPostService
    {
        Task AddPost(Post post);

        Task EditPost(Post post);

        Task DeletePost(int id);
    }
}
