using Microsoft.EntityFrameworkCore;
using Models;

public class AppDbContext : DbContext{
    public AppDbContext (DbContextOptions<AppDbContext> options)
    // public AppDbContext (DbContextOption<AppDbContext options>)

    : base(options)
    {

    }

    public DbSet<User> Users {get; set; }
}