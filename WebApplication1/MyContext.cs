using Microsoft.EntityFrameworkCore;

namespace WebApplication1;

public class MyContext : DbContext
{
    public DbSet<MyEntity> MyEntities { get; set; }

    public MyContext(DbContextOptions<MyContext> options) : base(options)
    {

    }
}
