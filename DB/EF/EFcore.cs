using Microsoft.EntityFrameworkCore;
using Middlewear.DB.Entity;

namespace Middlewear.DB.EF;

public class EFcore : DbContext 
{
    public EFcore(DbContextOptions<EFcore> options) : base(options)
    {

    }
    public DbSet<User> Users { get; set; }
}
