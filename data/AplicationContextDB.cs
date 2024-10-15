using Microsoft.EntityFrameworkCore;
using SimpleCrudApp.client.models;
using SimpleCrudApp.Model.Vendas;
using SimpleCrudApp.models;
namespace SimpleCrudApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Products> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Client> Clientes { get; set; }  
        public DbSet<Venda> Vendas { get; set; }  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeamento explícito da tabela 'produtos'
            modelBuilder.Entity<Products>().ToTable("produtos");

            // Mapeamento explícito da tabela 'usuarios'
            modelBuilder.Entity<Usuario>().ToTable("usuarios");

            modelBuilder.Entity<Client>().ToTable("clientes");

            modelBuilder.Entity<Venda>().ToTable("PedidoVendas");

        }
    }
}
