using Designophy.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Designophy.DataAccess
{
    public class AppDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<SubCategory> SubCategories { get; set; }

        public DbSet<Blog> Blogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.
                Entity<Category>()
                .HasMany(h => h.SubCategories)
                .WithMany(h => h.Categories);

            modelBuilder
                .Entity<Blog>()
                .HasMany(h => h.SubCategories)
                .WithMany(h => h.Blogs);

            modelBuilder
                .Entity<Blog>()
                .HasOne(h => h.User)
                .WithMany(h => h.Blogs);
        }
    }
}
