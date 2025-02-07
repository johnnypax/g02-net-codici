using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace G02_06_EF_DB_Negozio.Models;

public partial class G02DfNegozioContext : DbContext
{

    public G02DfNegozioContext(DbContextOptions<G02DfNegozioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Prodotto> Prodottos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Prodotto>(entity =>
        {
            entity.HasKey(e => e.ProdottoId).HasName("PK__Prodotto__3AB6597582DC2700");

            entity.ToTable("Prodotto");

            entity.HasIndex(e => e.Codice, "UQ__Prodotto__40F9C18BC1A32D1C").IsUnique();

            entity.Property(e => e.ProdottoId).HasColumnName("prodottoID");
            entity.Property(e => e.Codice)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("codice");
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Prezzo)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("prezzo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
