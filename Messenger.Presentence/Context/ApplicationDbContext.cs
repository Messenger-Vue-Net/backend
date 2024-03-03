using Messenger.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Messenger.Presentence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<Message> Messages { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserGroup>()
                .HasOne(gu => gu.Group)
                .WithMany(g => g.Users)
                .HasForeignKey(gu => gu.GroupId);
        }
    }
}
