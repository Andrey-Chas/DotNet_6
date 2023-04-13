using Assignment.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Data
{
    public class DbPosts : DbContext
    {
        public DbPosts(DbContextOptions<DbPosts> options) 
            : base(options)
        {

        }

        public DbSet<Post> Post { get; set; } = default!;
    }
}
