using G02_07_EF_CF_OTM.Models;
using Microsoft.EntityFrameworkCore;

namespace G02_07_EF_CF_OTM.Context
{
    public class LibrerieContext : DbContext
    {
        public LibrerieContext(DbContextOptions<LibrerieContext> options) : base(options) { }

        public DbSet<Autore> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autore>()
                .HasMany(a => a.Libri)
                .WithOne(l => l.AutoreNav)
                .HasForeignKey(l => l.AutoreRIF);

            modelBuilder.Entity<Autore>()
                .HasIndex(a => a.Codice)
                .IsUnique();

            modelBuilder.Entity<Libro>()
                .HasIndex(a => a.Isbn)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }


    }
}
