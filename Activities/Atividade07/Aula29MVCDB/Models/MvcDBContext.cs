using Microsoft.EntityFrameworkCore;

namespace Aula29MVCDB.Models;

public class MvcDBContext : DbContext
{
    public DbSet<Cliente> Cliente { get; set; }

    public DbSet<Pedido> Pedido { get; set; }

    public MvcDBContext(DbContextOptions<MvcDBContext> options) : base(options)
    {

    }
}