using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexto
{
    public class DbContextBase : IdentityDbContext<Usuario>
    {
        public DbContextBase(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Categoria> Categoria { set; get; }
        public DbSet<Cliente> Cliente { set; get; }
        public DbSet<ContaPagar> ContaPagar { set; get; }
        public DbSet<ContasReceber> ContasReceber { set; get; }
        public DbSet<FormaPagamento> FormaPagamento { set; get; }
        public DbSet<Fornecedor> Fornecedor { set; get; }
        public DbSet<Igreja> Igreja { set; get; }
        public DbSet<Membro> Membros { set; get; }
        public DbSet<Mesa> Mesa { set; get; }
        public DbSet<Usuario> Usuarios { set; get; }
        public DbSet<Produto> Produto { set; get; }
        public DbSet<Venda> Venda { set; get; }
        public DbSet<VendaItens> VendaItens { set; get; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Usuario>().ToTable("Asp.NetUsers").HasKey(t => t.Id);
            base.OnModelCreating(builder);
        }

        public string ObterStringConexao()
        {
            return "Data Source=localhost\\SQLEXPRESS01; Initial Catalog=Teste1245;;Integrated Security=False;User ID=sa;Password=fdas*2018;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
        }
    }
}
