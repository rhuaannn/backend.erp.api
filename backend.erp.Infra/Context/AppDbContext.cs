using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.erp.Domain.Model;
using backend.erp.Domain.ValueObject;
// NÃO inclua using backend.erp.Domain.ValueObject; aqui para evitar ambiguidades

namespace backend.erp.Infra.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Usuarios> users { get; set; }
        public DbSet<Clientes> client { get; set; }
        public DbSet<Fornecedores> suppliers { get; set; }
        public DbSet<Produtos> products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).IsRequired();

        

                entity.Property(e => e.Senha).IsRequired();
                entity.Property(e => e.DataCadastro).IsRequired();
                entity.Property(e => e.Situacao).IsRequired();
                entity.Property(e => e.Email).IsRequired();

            });

            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).IsRequired();

                entity.Property(e => e.Documento)
                    .HasConversion(
                        v => v.ToString(),
                        v => new backend.erp.Domain.ValueObject.Documento(v))
                    .IsRequired();

                entity.Property(e => e.DataCadastro).IsRequired();
            });

            modelBuilder.Entity<Fornecedores>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(f => f.Nome).IsRequired();

                entity.Property(f => f.Documento)
                    .HasConversion(
                        v => v.ToString(),
                        v => new backend.erp.Domain.ValueObject.Documento(v))
                    .IsRequired();

                entity.Property(f => f.Situacao).IsRequired();
                entity.HasMany(f => f.Produtos)
                      .WithOne(p => p.Fornecedor)
                      .HasForeignKey(p => p.FornecedorId);
            });

            modelBuilder.Entity<Produtos>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).IsRequired();
                entity.Property(e => e.Validade).IsRequired();
                entity.Property(e => e.Quantidade).IsRequired();
                entity.Property(e => e.Preco).IsRequired();
            });
        }
    }
}