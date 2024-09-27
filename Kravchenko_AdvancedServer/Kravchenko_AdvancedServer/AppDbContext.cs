using Kravchenko_AdvancedServer.Models;
using Kravchenko_AdvancedServer.Models.View;
using Microsoft.EntityFrameworkCore;
using Npgsql;
namespace Kravchenko_AdvancedServer;

public class AppDbContext: DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<News> News { get; set; }
    public DbSet<Tag> Tags { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
        //Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(x => x.Id);
        
        modelBuilder.Entity<News>().HasKey(x => x.Id);
        modelBuilder.Entity<News>().Property(x => x.Id).UseIdentityAlwaysColumn();
        
        modelBuilder.Entity<Tag>().HasKey(x => x.Id);
        modelBuilder.Entity<Tag>().Property(x => x.Id).UseIdentityAlwaysColumn();
        
        modelBuilder.Entity<News>().HasOne(x => x.User);
        
        modelBuilder.Entity<News>()
            .HasMany(x => x.Tags)
            .WithMany(x => x.News);
    }
}