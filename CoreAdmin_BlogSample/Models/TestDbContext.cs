using Microsoft.EntityFrameworkCore;

namespace CoreAdmin_BlogSample.Models
{
    public class TestDbContext : DbContext
    {
        public DbSet<BlogPost> BlogPosts { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public TestDbContext(DbContextOptions<TestDbContext> contextOptions) : base(contextOptions)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            this.Database.EnsureCreated();
        }
    }
}
