using Microsoft.EntityFrameworkCore;
using WatchTime.Models;

namespace WatchTime.DatabaseContext
{
  public class UserDbContext : DbContext
  {
    public UserDbContext() { }

    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
      AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

      ///Database.Migrate();
    }

    public DbSet<Users> User { get; set; }
    public DbSet<ContactUS> ContactUs { get; set; }

    public DbSet<Brand> Brand { get; set; }

    public DbSet<Quantity> Quantity { get; set; }
  }
}
