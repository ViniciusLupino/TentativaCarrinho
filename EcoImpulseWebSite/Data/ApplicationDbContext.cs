using EcoImpulseWebSite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace EcoImpulseWebSite.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //public DbSet<ExemploNoSingular> ExemploNoPlural { get; set; }

        public DbSet<CategoriaProduto> CategoriaProdutos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Carrinho> Carrinhos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<ExemploNoSingular>()
            //    .ToTable("tbExemploNoSingular")
            //    .HasKey(u => u.IdExemploNoSingular);

            modelBuilder.Entity<CategoriaProduto>()
                .ToTable("tbCategoriaProduto")
                .HasKey(u => u.IdCategoriaProduto);

            modelBuilder.Entity<Produto>()
                .ToTable("tbProduto").HasKey(u => u.IdProduto);

            modelBuilder.Entity<Carrinho>()
                .ToTable("tbCarrinho")
                .HasKey(u => u.IdCarrinho);



        }
    }
}
