namespace User_ASP.Helpers;

using Microsoft.EntityFrameworkCore;
using User_ASP.Entities;

public class DataContext : DbContext
{
    // get connectionstring from appsettings.json
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("UserDataBase"));
    }

    public DbSet<User> Users { get; set; }
}
