using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyWebApi.Domain;

namespace MyWebApi.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }


        public DbSet<Post> Posts { get; set; }

        public DbSet<RefreshToken> ResfreshTokens { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Menu> Menus { get; set; }

        public DbSet<Ingredients> Ingredients { get; set; }

        public DbSet<PostTag> PostTags { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PostTag>().Ignore(xx => xx.Post).HasKey(x => new { x.PostId, x.TagName });
        }

    }
}
