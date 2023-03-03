using System;
using Domain.MainModule.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Infrastructure.Data.Context
{
    public partial class SofttekBDContext : DbContext
    {
        public SofttekBDContext()
        {
        }

        public SofttekBDContext(DbContextOptions<SofttekBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ProductoEntity> Productos { get; set; }
        public virtual DbSet<UsuarioEntity> Usuarios { get; set; }
        public virtual DbSet<VentaDiariaEntity> VentasDiarias { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<ProductoEntity>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__Producto__09889210C4170B13");

                entity.ToTable("Producto");

                entity.Property(e => e.DescProducto)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.Precio).HasColumnType("decimal(6, 2)");
            });

            modelBuilder.Entity<UsuarioEntity>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF978753C357");

                entity.ToTable("Usuario");

                entity.Property(e => e.ApellidoMaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dni)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VentaDiariaEntity>(entity =>
            {
                entity.HasKey(e => e.IdVenta)
                    .HasName("PK__VentasDi__BC1240BD0E0D6EB5");

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.FechaVenta).HasColumnType("datetime");

                //entity.HasOne(d => d.IdProductoNavigation)
                //    .WithMany(p => p.VentasDiaria)
                //    .HasForeignKey(d => d.IdProducto)
                //    .HasConstraintName("FK__VentasDia__IdPro__2E1BDC42");

                //entity.HasOne(d => d.IdUsuarioVentaNavigation)
                //    .WithMany(p => p.VentasDiaria)
                //    .HasForeignKey(d => d.IdUsuarioVenta)
                //    .HasConstraintName("FK__VentasDia__IdUsu__2F10007B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
