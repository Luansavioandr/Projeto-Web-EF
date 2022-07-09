using Microsoft.EntityFrameworkCore;
using Projeto_Web_EF.Entidades;

namespace Projeto_Web_EF.Contexto
{
    public class EFContexto : DbContext
    {
        public EFContexto(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Carro> Carros { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Funcionarios> Funcionarios { get; set; }
        public DbSet<Endereco> Endereco { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=luan;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            optionsBuilder.UseLazyLoadingProxies();
        }

        
    }
}

