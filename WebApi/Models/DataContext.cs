using Microsoft.EntityFrameworkCore;

namespace ApiWeb.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Compra> Compras {get; set;}
        public DbSet<Cartao> Cartao {get; set;}
    }
}