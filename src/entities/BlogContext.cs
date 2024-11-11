using Microsoft.EntityFrameworkCore;

public class BlogContext : DbContext
{
    private readonly IConfiguration _configuration;

    public BlogContext(DbContextOptions<BlogContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnectionPostGree"));
        }
    }

    public DbSet<Post> Posts { get; set; }
    public DbSet<User> Users { get; set; }
}
