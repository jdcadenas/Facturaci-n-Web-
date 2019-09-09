namespace SistemaFacturacionWeb.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=Model2")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<articulo> articulo { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<bitacora> bitacora { get; set; }
        public virtual DbSet<bodega> bodega { get; set; }
        public virtual DbSet<cliente> cliente { get; set; }
        public virtual DbSet<Compras> Compras { get; set; }
        public virtual DbSet<ComprasDetalles> ComprasDetalles { get; set; }
        public virtual DbSet<detallesempleado> detallesempleado { get; set; }
        public virtual DbSet<impuesto> impuesto { get; set; }
        public virtual DbSet<modopago> modopago { get; set; }
        public virtual DbSet<Presupuesto> Presupuesto { get; set; }
        public virtual DbSet<PresupuestoDetalles> PresupuestoDetalles { get; set; }
        public virtual DbSet<proveedor> proveedor { get; set; }
        public virtual DbSet<sucursal> sucursal { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tipodocumento> tipodocumento { get; set; }
        public virtual DbSet<Ventas> Ventas { get; set; }
        public virtual DbSet<VentasDetalles> VentasDetalles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<articulo>()
                .Property(e => e.NombreArticulo)
                .IsUnicode(false);

            modelBuilder.Entity<articulo>()
                .Property(e => e.StockMaxArticulo)
                .IsFixedLength();

            modelBuilder.Entity<articulo>()
                .Property(e => e.CantidadArticulo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<articulo>()
                .Property(e => e.DescripcionArticulo)
                .IsUnicode(false);

            modelBuilder.Entity<articulo>()
                .Property(e => e.UnidadMedidaArticulo)
                .IsUnicode(false);

            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.bitacora)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.IdUsuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.detallesempleado)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.IdUsers)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.sucursal)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.IdResponsableSucursal)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<bitacora>()
                .Property(e => e.ModuloBitacora)
                .IsFixedLength();

            modelBuilder.Entity<bodega>()
                .Property(e => e.NombreBodega)
                .IsUnicode(false);

            modelBuilder.Entity<ComprasDetalles>()
                .Property(e => e.Cantidad)
                .HasPrecision(18, 0);

            modelBuilder.Entity<impuesto>()
                .Property(e => e.NombreImpuesto)
                .IsUnicode(false);

            modelBuilder.Entity<modopago>()
                .Property(e => e.NombreModoPago)
                .IsUnicode(false);

            modelBuilder.Entity<modopago>()
                .Property(e => e.DetalleModoPago)
                .IsUnicode(false);

            modelBuilder.Entity<Presupuesto>()
                .HasMany(e => e.PresupuestoDetalles)
                .WithRequired(e => e.Presupuesto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PresupuestoDetalles>()
                .Property(e => e.Cantidad)
                .HasPrecision(18, 0);

            modelBuilder.Entity<proveedor>()
                .Property(e => e.RazonSocialProveedor)
                .IsUnicode(false);

            modelBuilder.Entity<proveedor>()
                .Property(e => e.RifProveedor)
                .IsUnicode(false);

            modelBuilder.Entity<proveedor>()
                .Property(e => e.DireccionProveedor)
                .IsUnicode(false);

            modelBuilder.Entity<proveedor>()
                .Property(e => e.DetallesProveedor)
                .IsUnicode(false);

            modelBuilder.Entity<proveedor>()
                .Property(e => e.NombreContactoProveedor)
                .IsUnicode(false);

            modelBuilder.Entity<proveedor>()
                .Property(e => e.SitioWebProveedor)
                .IsUnicode(false);

            modelBuilder.Entity<sucursal>()
                .Property(e => e.NombreSucursal)
                .IsUnicode(false);

            modelBuilder.Entity<sucursal>()
                .Property(e => e.DetallesSucursal)
                .IsUnicode(false);

            modelBuilder.Entity<sucursal>()
                .Property(e => e.DireccionSucursal)
                .IsUnicode(false);

            modelBuilder.Entity<sucursal>()
                .HasMany(e => e.bodega)
                .WithRequired(e => e.sucursal)
                .HasForeignKey(e => e.IdSucursalBodega)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sucursal>()
                .HasMany(e => e.tipodocumento)
                .WithRequired(e => e.sucursal)
                .HasForeignKey(e => e.IdSucursalEncabezado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tipodocumento>()
                .Property(e => e.TipoEncabezado)
                .IsUnicode(false);

            modelBuilder.Entity<tipodocumento>()
                .Property(e => e.TituloEncabezado)
                .IsUnicode(false);

            modelBuilder.Entity<Ventas>()
                .HasMany(e => e.VentasDetalles)
                .WithRequired(e => e.Ventas)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VentasDetalles>()
                .Property(e => e.Cantidad)
                .HasPrecision(18, 0);
        }
    }
}
