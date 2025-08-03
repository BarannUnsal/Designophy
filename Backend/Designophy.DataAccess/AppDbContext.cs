using Designophy.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Designophy.DataAccess
{
    public class AppDbContext : IdentityDbContext
    {
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
