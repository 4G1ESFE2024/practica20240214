using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Practica20240214.Models
{
    public partial class Practica20240214DBContext : DbContext
    {
        public Practica20240214DBContext()
        {
        }

        public Practica20240214DBContext(DbContextOptions<Practica20240214DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ropa> Ropas { get; set; } = null!;
        public virtual DbSet<Talla> Tallas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=M17-C1;Initial Catalog=Practica20240214DB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ropa>(entity =>
            {
                entity.HasKey(e => e.IdRopa)
                    .HasName("PK__Ropas__B436B0C5A9ED309A");

                entity.Property(e => e.NombreRopa).HasMaxLength(100);

                entity.Property(e => e.TipoRopa).HasMaxLength(50);

                entity.HasOne(d => d.IdTallaNavigation)
                    .WithMany(p => p.Ropas)
                    .HasForeignKey(d => d.IdTalla)
                    .HasConstraintName("FK__Ropas__IdTalla__267ABA7A");
            });

            modelBuilder.Entity<Talla>(entity =>
            {
                entity.HasKey(e => e.IdTalla)
                    .HasName("PK__Tallas__E95BE94339BB1F7B");

                entity.Property(e => e.NombreTalla).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
