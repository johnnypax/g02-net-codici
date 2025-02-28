using Microsoft.EntityFrameworkCore;
using MinimalAPI_06_EF_MTM.Models;

namespace MinimalAPI_06_EF_MTM.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Prodotto>  Prodottos { get; set; }
        public DbSet<Categoria>  Categorias { get; set; }
        public DbSet<ProdottoCategoria>  ProdottoCategorias { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdottoCategoria>()
                .HasKey(pc => new { pc.ProdottoId, pc.CategoriaId });

            modelBuilder.Entity<ProdottoCategoria>()
                .HasOne(pc => pc.ProdottoNav)
                .WithMany(p => p.ProdottoCategorias)
                .HasForeignKey(pc => pc.ProdottoId);

            modelBuilder.Entity<ProdottoCategoria>()
                .HasOne(pc => pc.CategoriaNav)
                .WithMany(c => c.ProdottoCategorias)
                .HasForeignKey(pc => pc.CategoriaId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
