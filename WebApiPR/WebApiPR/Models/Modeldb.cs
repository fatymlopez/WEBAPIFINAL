namespace WebApiPR.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Modeldb : DbContext
    {
        public Modeldb()
            : base("name=Modeldb")
        {
        }

        public DbSet<categorias> categorias { get; set; }
        public DbSet<cliente> cliente { get; set; }
        public DbSet<detallereservacion> detallereservacion { get; set; }
        public DbSet<estados> estados { get; set; }
        public DbSet<productos> productos { get; set; }
        public DbSet<reservacion> reservacion { get; set; }
        public DbSet<ubicacion> ubicacion { get; set; }
        public DbSet<usuapp> usuapp { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<categorias>()
                .Property(e => e.nomcategoria)
                .IsUnicode(false);

            modelBuilder.Entity<categorias>()
                .HasMany(e => e.productos)
                .WithRequired(e => e.categorias)
                .HasForeignKey(e => e.idcategoria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.nombrecl)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.cellcl)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.emailcl)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.passcl)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .HasMany(e => e.reservacion)
                .WithOptional(e => e.cliente)
                .HasForeignKey(e => e.idcliente);

            modelBuilder.Entity<detallereservacion>()
                .Property(e => e.precio)
                .HasPrecision(6, 2);

            modelBuilder.Entity<detallereservacion>()
                .Property(e => e.subtotal)
                .HasPrecision(6, 2);

            modelBuilder.Entity<estados>()
                .Property(e => e.nomestado)
                .IsUnicode(false);

            modelBuilder.Entity<estados>()
                .HasMany(e => e.productos)
                .WithOptional(e => e.estados)
                .HasForeignKey(e => e.idestado);

            modelBuilder.Entity<productos>()
                .Property(e => e.nomproducto)
                .IsUnicode(false);

            modelBuilder.Entity<productos>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<productos>()
                .Property(e => e.precio)
                .HasPrecision(6, 2);

            modelBuilder.Entity<productos>()
                .HasMany(e => e.detallereservacion)
                .WithRequired(e => e.productos)
                .HasForeignKey(e => e.idproducto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<reservacion>()
                .Property(e => e.total)
                .HasPrecision(6, 2);

            modelBuilder.Entity<reservacion>()
                .HasMany(e => e.detallereservacion)
                .WithRequired(e => e.reservacion)
                .HasForeignKey(e => e.idreservacion);

            modelBuilder.Entity<ubicacion>()
                .Property(e => e.nomubicacion)
                .IsUnicode(false);

            modelBuilder.Entity<ubicacion>()
                .HasMany(e => e.reservacion)
                .WithOptional(e => e.ubicacion)
                .HasForeignKey(e => e.idubicacion);

            modelBuilder.Entity<usuapp>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<usuapp>()
                .Property(e => e.usuario)
                .IsUnicode(false);

            modelBuilder.Entity<usuapp>()
                .Property(e => e.emailusu)
                .IsUnicode(false);

            modelBuilder.Entity<usuapp>()
                .Property(e => e.passusu)
                .IsUnicode(false);
        }
    }
}
