using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TiendaOnline.Models
{
    public partial class tiendaonlineDBContext : DbContext
    {
        public tiendaonlineDBContext()
        {
        }

        public tiendaonlineDBContext(DbContextOptions<tiendaonlineDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Cupon> Cupon { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Detalledeproducto> Detalledeproducto { get; set; }
        public virtual DbSet<Detalledevendedor> Detalledevendedor { get; set; }
        public virtual DbSet<Direccion> Direccion { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Estadodeorden> Estadodeorden { get; set; }
        public virtual DbSet<Lineadeorden> Lineadeorden { get; set; }
        public virtual DbSet<Metododeenvio> Metododeenvio { get; set; }
        public virtual DbSet<Municipio> Municipio { get; set; }
        public virtual DbSet<Orden> Orden { get; set; }
        public virtual DbSet<Paypal> Paypal { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Registrodeproductos> Registrodeproductos { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Subcategoria> Subcategoria { get; set; }
        public virtual DbSet<Sucursal> Sucursal { get; set; }
        public virtual DbSet<Tarjeta> Tarjeta { get; set; }
        public virtual DbSet<Tipodedescuento> Tipodedescuento { get; set; }
        public virtual DbSet<Tipodepago> Tipodepago { get; set; }
        public virtual DbSet<Tipodevendedor> Tipodevendedor { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-97D2E6U\\SQLEXPRESS;Database=tiendaonlineDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("CATEGORIA");

                entity.Property(e => e.IdCategoria).HasColumnName("ID_CATEGORIA");

                entity.Property(e => e.NombreCategoria)
                    .IsRequired()
                    .HasColumnName("NOMBRE_CATEGORIA")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Cupon>(entity =>
            {
                entity.HasKey(e => e.IdCupon)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("CUPON");

                entity.Property(e => e.IdCupon)
                    .HasColumnName("ID_CUPON")
                    .ValueGeneratedNever();

                entity.Property(e => e.CodigoCupon)
                    .HasColumnName("CODIGO_CUPON")
                    .HasColumnType("text");

                entity.Property(e => e.Descripciondelcupon)
                    .HasColumnName("DESCRIPCIONDELCUPON")
                    .HasColumnType("text");

                entity.Property(e => e.EstadoCupon).HasColumnName("ESTADO_CUPON");

                entity.Property(e => e.Fechadecreacion)
                    .HasColumnName("FECHADECREACION")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fechadevencimiento)
                    .HasColumnName("FECHADEVENCIMIENTO")
                    .HasColumnType("datetime");

                entity.Property(e => e.MontoCupon)
                    .HasColumnName("MONTO_CUPON")
                    .HasColumnType("decimal(2, 2)");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.IdDepartamento)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("DEPARTAMENTO");

                entity.HasIndex(e => e.IdMunicipio)
                    .HasName("TIENE_FK");

                entity.Property(e => e.IdDepartamento)
                    .HasColumnName("ID_DEPARTAMENTO")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdMunicipio).HasColumnName("ID_MUNICIPIO");

                entity.Property(e => e.NombreDepartamento)
                    .HasColumnName("NOMBRE_DEPARTAMENTO")
                    .HasColumnType("text");

                entity.HasOne(d => d.IdMunicipioNavigation)
                    .WithMany(p => p.Departamento)
                    .HasForeignKey(d => d.IdMunicipio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DEPARTAM_TIENE_MUNICIPI");
            });

            modelBuilder.Entity<Detalledeproducto>(entity =>
            {
                entity.HasKey(e => e.IdDetalle)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("DETALLEDEPRODUCTO");

                entity.Property(e => e.IdDetalle)
                    .HasColumnName("ID_DETALLE")
                    .ValueGeneratedNever();

                entity.Property(e => e.Color)
                    .HasColumnName("COLOR")
                    .HasColumnType("text");

                entity.Property(e => e.Escripciondeproducto)
                    .IsRequired()
                    .HasColumnName("ESCRIPCIONDEPRODUCTO")
                    .HasColumnType("text");

                entity.Property(e => e.Modelo)
                    .HasColumnName("MODELO")
                    .HasColumnType("text");

                entity.Property(e => e.Pesokg)
                    .HasColumnName("PESOKG")
                    .HasColumnType("decimal(2, 2)");

                entity.Property(e => e.Talla)
                    .HasColumnName("TALLA")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Detalledevendedor>(entity =>
            {
                entity.HasKey(e => e.IdVendedor)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("DETALLEDEVENDEDOR");

                entity.HasIndex(e => e.DirIdDireccion)
                    .HasName("DIRECCIONDELVENDEDOR_FK");

                entity.HasIndex(e => e.IdDireccion)
                    .HasName("UBICACIONDELNEGOCIO_FK");

                entity.HasIndex(e => e.IdEmpresa)
                    .HasName("POSEEDATOSDE2_FK");

                entity.HasIndex(e => e.IdRegistro)
                    .HasName("REGISTRA_FK");

                entity.HasIndex(e => e.IdTarjeta)
                    .HasName("PAGOYGANANCIASPOR_FK");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("PUEDEREPRESENTAR_FK");

                entity.HasIndex(e => e.TarIdTarjeta)
                    .HasName("TARJETACOMERCIAL_FK");

                entity.Property(e => e.IdVendedor)
                    .HasColumnName("ID_VENDEDOR")
                    .ValueGeneratedNever();

                entity.Property(e => e.Correocomercial)
                    .HasColumnName("CORREOCOMERCIAL")
                    .HasColumnType("text");

                entity.Property(e => e.DirIdDireccion).HasColumnName("DIR_ID_DIRECCION");

                entity.Property(e => e.IdDireccion).HasColumnName("ID_DIRECCION");

                entity.Property(e => e.IdEmpresa).HasColumnName("ID_EMPRESA");

                entity.Property(e => e.IdRegistro)
                    .HasColumnName("ID_REGISTRO")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IdTarjeta).HasColumnName("ID_TARJETA");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.Nombrecomercial)
                    .HasColumnName("NOMBRECOMERCIAL")
                    .HasColumnType("text");

                entity.Property(e => e.TarIdTarjeta).HasColumnName("TAR_ID_TARJETA");

                entity.HasOne(d => d.DirIdDireccionNavigation)
                    .WithMany(p => p.DetalledevendedorDirIdDireccionNavigation)
                    .HasForeignKey(d => d.DirIdDireccion)
                    .HasConstraintName("FK_DETALLED_DIRECCION_DIRECCIO");

                entity.HasOne(d => d.IdDireccionNavigation)
                    .WithMany(p => p.DetalledevendedorIdDireccionNavigation)
                    .HasForeignKey(d => d.IdDireccion)
                    .HasConstraintName("FK_DETALLED_UBICACION_DIRECCIO");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Detalledevendedor)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK_DETALLED_POSEEDATO_EMPRESA");

                entity.HasOne(d => d.IdRegistroNavigation)
                    .WithMany(p => p.Detalledevendedor)
                    .HasForeignKey(d => d.IdRegistro)
                    .HasConstraintName("FK_DETALLED_REGISTRA_REGISTRO");

                entity.HasOne(d => d.IdTarjetaNavigation)
                    .WithMany(p => p.DetalledevendedorIdTarjetaNavigation)
                    .HasForeignKey(d => d.IdTarjeta)
                    .HasConstraintName("FK_DETALLED_PAGOYGANA_TARJETA");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Detalledevendedor)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_DETALLED_PUEDEREPR_USUARIO");

                entity.HasOne(d => d.TarIdTarjetaNavigation)
                    .WithMany(p => p.DetalledevendedorTarIdTarjetaNavigation)
                    .HasForeignKey(d => d.TarIdTarjeta)
                    .HasConstraintName("FK_DETALLED_TARJETACO_TARJETA");
            });

            modelBuilder.Entity<Direccion>(entity =>
            {
                entity.HasKey(e => e.IdDireccion)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("DIRECCION");

                entity.HasIndex(e => e.IdDepartamento)
                    .HasName("POSEE_FK");

                entity.HasIndex(e => e.IdSucursal)
                    .HasName("UBICACIONDE_SUCURSAL_FK");

                entity.Property(e => e.IdDireccion)
                    .HasColumnName("ID_DIRECCION")
                    .ValueGeneratedNever();

                entity.Property(e => e.Codigopostal).HasColumnName("CODIGOPOSTAL");

                entity.Property(e => e.Direcciondetallada)
                    .HasColumnName("DIRECCIONDETALLADA")
                    .HasColumnType("text");

                entity.Property(e => e.IdDepartamento).HasColumnName("ID_DEPARTAMENTO");

                entity.Property(e => e.IdSucursal).HasColumnName("ID_SUCURSAL");

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.Direccion)
                    .HasForeignKey(d => d.IdDepartamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DIRECCIO_POSEE_DEPARTAM");

                entity.HasOne(d => d.IdSucursalNavigation)
                    .WithMany(p => p.Direccion)
                    .HasForeignKey(d => d.IdSucursal)
                    .HasConstraintName("FK_DIRECCIO_UBICACION_SUCURSAL");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("EMPRESA");

                entity.HasIndex(e => e.IdVendedor)
                    .HasName("POSEEDATOSDE_FK");

                entity.Property(e => e.IdEmpresa)
                    .HasColumnName("ID_EMPRESA")
                    .ValueGeneratedNever();

                entity.Property(e => e.CorreoAtencionalcliente)
                    .HasColumnName("CORREO_ATENCIONALCLIENTE")
                    .HasColumnType("text");

                entity.Property(e => e.IdVendedor).HasColumnName("ID_VENDEDOR");

                entity.Property(e => e.TelefonoAtencionalcliente).HasColumnName("TELEFONO_ATENCIONALCLIENTE");

                entity.HasOne(d => d.IdVendedorNavigation)
                    .WithMany(p => p.Empresa)
                    .HasForeignKey(d => d.IdVendedor)
                    .HasConstraintName("FK_EMPRESA_POSEEDATO_DETALLED");
            });

            modelBuilder.Entity<Estadodeorden>(entity =>
            {
                entity.HasKey(e => e.IdEstadodeorden)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("ESTADODEORDEN");

                entity.Property(e => e.IdEstadodeorden)
                    .HasColumnName("ID_ESTADODEORDEN")
                    .ValueGeneratedNever();

                entity.Property(e => e.EstadoDeorden1).HasColumnName("ESTADO_DEORDEN");
            });

            modelBuilder.Entity<Lineadeorden>(entity =>
            {
                entity.HasKey(e => e.IdLineadeorden)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("LINEADEORDEN");

                entity.HasIndex(e => e.IdOrden)
                    .HasName("SECOMPONEPOR_FK");

                entity.HasIndex(e => e.IdProducto)
                    .HasName("TENDRA_FK");

                entity.Property(e => e.IdLineadeorden)
                    .HasColumnName("ID_LINEADEORDEN")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cantidaddeproducto).HasColumnName("CANTIDADDEPRODUCTO");

                entity.Property(e => e.IdOrden).HasColumnName("ID_ORDEN");

                entity.Property(e => e.IdProducto).HasColumnName("ID_PRODUCTO");

                entity.Property(e => e.Subtotal)
                    .HasColumnName("SUBTOTAL")
                    .HasColumnType("decimal(4, 2)");

                entity.HasOne(d => d.IdOrdenNavigation)
                    .WithMany(p => p.Lineadeorden)
                    .HasForeignKey(d => d.IdOrden)
                    .HasConstraintName("FK_LINEADEO_SECOMPONE_ORDEN");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Lineadeorden)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK_LINEADEO_TENDRA_PRODUCTO");
            });

            modelBuilder.Entity<Metododeenvio>(entity =>
            {
                entity.HasKey(e => e.IdMetododeenvio)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("METODODEENVIO");

                entity.HasIndex(e => e.IdEmpresa)
                    .HasName("BRINDA_FK");

                entity.Property(e => e.IdMetododeenvio)
                    .HasColumnName("ID_METODODEENVIO")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdEmpresa).HasColumnName("ID_EMPRESA");

                entity.Property(e => e.Maxdediasdeenvio).HasColumnName("MAXDEDIASDEENVIO");

                entity.Property(e => e.Mindediasdeenvio).HasColumnName("MINDEDIASDEENVIO");

                entity.Property(e => e.Montoporenvio)
                    .HasColumnName("MONTOPORENVIO")
                    .HasColumnType("decimal(2, 2)");

                entity.Property(e => e.NombreMetododeenvio)
                    .HasColumnName("NOMBRE_METODODEENVIO")
                    .HasColumnType("text");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Metododeenvio)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK_METODODE_BRINDA_EMPRESA");
            });

            modelBuilder.Entity<Municipio>(entity =>
            {
                entity.HasKey(e => e.IdMunicipio)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("MUNICIPIO");

                entity.Property(e => e.IdMunicipio)
                    .HasColumnName("ID_MUNICIPIO")
                    .ValueGeneratedNever();

                entity.Property(e => e.NombreMunicipio)
                    .HasColumnName("NOMBRE_MUNICIPIO")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Orden>(entity =>
            {
                entity.HasKey(e => e.IdOrden)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("ORDEN");

                entity.HasIndex(e => e.IdCupon)
                    .HasName("DISMINUIDAPOR_FK");

                entity.HasIndex(e => e.IdEstadodeorden)
                    .HasName("PUEDETENER_FK");

                entity.HasIndex(e => e.IdMetododeenvio)
                    .HasName("ENVIOS_FK");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("SOLICITA_FK");

                entity.Property(e => e.IdOrden)
                    .HasColumnName("ID_ORDEN")
                    .ValueGeneratedNever();

                entity.Property(e => e.Fechadecompra)
                    .HasColumnName("FECHADECOMPRA")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCupon).HasColumnName("ID_CUPON");

                entity.Property(e => e.IdEstadodeorden).HasColumnName("ID_ESTADODEORDEN");

                entity.Property(e => e.IdMetododeenvio).HasColumnName("ID_METODODEENVIO");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.Total)
                    .HasColumnName("TOTAL")
                    .HasColumnType("decimal(4, 2)");

                entity.HasOne(d => d.IdCuponNavigation)
                    .WithMany(p => p.Orden)
                    .HasForeignKey(d => d.IdCupon)
                    .HasConstraintName("FK_ORDEN_DISMINUID_CUPON");

                entity.HasOne(d => d.IdEstadodeordenNavigation)
                    .WithMany(p => p.Orden)
                    .HasForeignKey(d => d.IdEstadodeorden)
                    .HasConstraintName("FK_ORDEN_PUEDETENE_ESTADODE");

                entity.HasOne(d => d.IdMetododeenvioNavigation)
                    .WithMany(p => p.Orden)
                    .HasForeignKey(d => d.IdMetododeenvio)
                    .HasConstraintName("FK_ORDEN_ENVIOS_METODODE");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Orden)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_ORDEN_SOLICITA_USUARIO");
            });

            modelBuilder.Entity<Paypal>(entity =>
            {
                entity.HasKey(e => e.IdPaypal)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("PAYPAL");

                entity.Property(e => e.IdPaypal)
                    .HasColumnName("ID_PAYPAL")
                    .ValueGeneratedNever();

                entity.Property(e => e.CorreoPaypal)
                    .HasColumnName("CORREO_PAYPAL")
                    .HasColumnType("text");

                entity.Property(e => e.PsswdPaypal)
                    .HasColumnName("PSSWD_PAYPAL")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("PRODUCTO");

                entity.HasIndex(e => e.IdDetalle)
                    .HasName("DESCRITO_FK");

                entity.HasIndex(e => e.IdEmpresa)
                    .HasName("HACEPUBLICIDAD_FK");

                entity.HasIndex(e => e.IdSubcategoria)
                    .HasName("ES_FK");

                entity.HasIndex(e => e.IdTipodedescuento)
                    .HasName("DESCUENTO_FK");

                entity.HasIndex(e => e.IdVendedor)
                    .HasName("VENDIDOPOR_FK");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("ID_PRODUCTO")
                    .ValueGeneratedNever();

                entity.Property(e => e.Codigodeproducto)
                    .IsRequired()
                    .HasColumnName("CODIGODEPRODUCTO")
                    .HasColumnType("text");

                entity.Property(e => e.Existencia).HasColumnName("EXISTENCIA");

                entity.Property(e => e.IdDetalle).HasColumnName("ID_DETALLE");

                entity.Property(e => e.IdEmpresa).HasColumnName("ID_EMPRESA");

                entity.Property(e => e.IdSubcategoria).HasColumnName("ID_SUBCATEGORIA");

                entity.Property(e => e.IdTipodedescuento).HasColumnName("ID_TIPODEDESCUENTO");

                entity.Property(e => e.IdVendedor).HasColumnName("ID_VENDEDOR");

                entity.Property(e => e.ImgProducto)
                    .IsRequired()
                    .HasColumnName("IMG_PRODUCTO")
                    .HasColumnType("image");

                entity.Property(e => e.NombreProducto)
                    .IsRequired()
                    .HasColumnName("NOMBRE_PRODUCTO")
                    .HasColumnType("text");

                entity.Property(e => e.Preciounitario)
                    .HasColumnName("PRECIOUNITARIO")
                    .HasColumnType("decimal(4, 2)");

                entity.HasOne(d => d.IdDetalleNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.IdDetalle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCTO_DESCRITO_DETALLED");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK_PRODUCTO_HACEPUBLI_EMPRESA");

                entity.HasOne(d => d.IdSubcategoriaNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.IdSubcategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCTO_ES_SUBCATEG");

                entity.HasOne(d => d.IdTipodedescuentoNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.IdTipodedescuento)
                    .HasConstraintName("FK_PRODUCTO_DESCUENTO_TIPODEDE");

                entity.HasOne(d => d.IdVendedorNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.IdVendedor)
                    .HasConstraintName("FK_PRODUCTO_VENDIDOPO_DETALLED");
            });

            modelBuilder.Entity<Registrodeproductos>(entity =>
            {
                entity.HasKey(e => e.IdRegistro)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("REGISTRODEPRODUCTOS");

                entity.HasIndex(e => e.IdProducto)
                    .HasName("VENDE_FK");

                entity.Property(e => e.IdRegistro)
                    .HasColumnName("ID_REGISTRO")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.IdProducto).HasColumnName("ID_PRODUCTO");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Registrodeproductos)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK_REGISTRO_VENDE_PRODUCTO");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("ROL");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("PUEDESER2_FK");

                entity.Property(e => e.IdRol)
                    .HasColumnName("ID_ROL")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.NombreRol)
                    .HasColumnName("NOMBRE_ROL")
                    .HasColumnType("text");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Rol)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ROL_ESELUSUAR_USUARIO");
            });

            modelBuilder.Entity<Subcategoria>(entity =>
            {
                entity.HasKey(e => e.IdSubcategoria)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("SUBCATEGORIA");

                entity.HasIndex(e => e.IdCategoria)
                    .HasName("PERTENECE_FK");

                entity.Property(e => e.IdSubcategoria)
                    .HasColumnName("ID_SUBCATEGORIA")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdCategoria).HasColumnName("ID_CATEGORIA");

                entity.Property(e => e.NombreSubcategoria)
                    .IsRequired()
                    .HasColumnName("NOMBRE_SUBCATEGORIA")
                    .HasColumnType("text");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Subcategoria)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SUBCATEG_PERTENECE_CATEGORI");
            });

            modelBuilder.Entity<Sucursal>(entity =>
            {
                entity.HasKey(e => e.IdSucursal)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("SUCURSAL");

                entity.HasIndex(e => e.IdDireccion)
                    .HasName("UBICACIONDE_SUCURSAL2_FK");

                entity.HasIndex(e => e.IdEmpresa)
                    .HasName("SEDISTRIBUYE_FK");

                entity.Property(e => e.IdSucursal)
                    .HasColumnName("ID_SUCURSAL")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdDireccion).HasColumnName("ID_DIRECCION");

                entity.Property(e => e.IdEmpresa).HasColumnName("ID_EMPRESA");

                entity.Property(e => e.NombreSucursal)
                    .HasColumnName("NOMBRE_SUCURSAL")
                    .HasColumnType("text");

                entity.HasOne(d => d.IdDireccionNavigation)
                    .WithMany(p => p.Sucursal)
                    .HasForeignKey(d => d.IdDireccion)
                    .HasConstraintName("FK_SUCURSAL_UBICACION_DIRECCIO");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Sucursal)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK_SUCURSAL_SEDISTRIB_EMPRESA");
            });

            modelBuilder.Entity<Tarjeta>(entity =>
            {
                entity.HasKey(e => e.IdTarjeta)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("TARJETA");

                entity.HasIndex(e => e.IdVendedor)
                    .HasName("TARJETACOMERCIAL2_FK");

                entity.Property(e => e.IdTarjeta)
                    .HasColumnName("ID_TARJETA")
                    .ValueGeneratedNever();

                entity.Property(e => e.CodigoTarjeta).HasColumnName("CODIGO_TARJETA");

                entity.Property(e => e.FechadevencimientoTarjeta)
                    .HasColumnName("FECHADEVENCIMIENTO_TARJETA")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdVendedor).HasColumnName("ID_VENDEDOR");

                entity.Property(e => e.Tipodetarjeta)
                    .HasColumnName("TIPODETARJETA")
                    .HasColumnType("text");

                entity.HasOne(d => d.IdVendedorNavigation)
                    .WithMany(p => p.Tarjeta)
                    .HasForeignKey(d => d.IdVendedor)
                    .HasConstraintName("FK_TARJETA_TARJETACO_DETALLED");
            });

            modelBuilder.Entity<Tipodedescuento>(entity =>
            {
                entity.HasKey(e => e.IdTipodedescuento)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("TIPODEDESCUENTO");

                entity.Property(e => e.IdTipodedescuento)
                    .HasColumnName("ID_TIPODEDESCUENTO")
                    .ValueGeneratedNever();

                entity.Property(e => e.Montodedescuento)
                    .HasColumnName("MONTODEDESCUENTO")
                    .HasColumnType("decimal(2, 2)");

                entity.Property(e => e.Nombredeldescuento)
                    .HasColumnName("NOMBREDELDESCUENTO")
                    .HasColumnType("text");

                entity.Property(e => e.Porcentajededescuento)
                    .HasColumnName("PORCENTAJEDEDESCUENTO")
                    .HasColumnType("decimal(2, 2)");
            });

            modelBuilder.Entity<Tipodepago>(entity =>
            {
                entity.HasKey(e => e.IdTipodepago)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("TIPODEPAGO");

                entity.HasIndex(e => e.IdPaypal)
                    .HasName("SEREALIZACON_FK");

                entity.HasIndex(e => e.IdTarjeta)
                    .HasName("COMPRACON_FK");

                entity.Property(e => e.IdTipodepago)
                    .HasColumnName("ID_TIPODEPAGO")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdPaypal).HasColumnName("ID_PAYPAL");

                entity.Property(e => e.IdTarjeta).HasColumnName("ID_TARJETA");

                entity.HasOne(d => d.IdPaypalNavigation)
                    .WithMany(p => p.Tipodepago)
                    .HasForeignKey(d => d.IdPaypal)
                    .HasConstraintName("FK_TIPODEPA_SEREALIZA_PAYPAL");

                entity.HasOne(d => d.IdTarjetaNavigation)
                    .WithMany(p => p.Tipodepago)
                    .HasForeignKey(d => d.IdTarjeta)
                    .HasConstraintName("FK_TIPODEPA_COMPRACON_TARJETA");
            });

            modelBuilder.Entity<Tipodevendedor>(entity =>
            {
                entity.HasKey(e => e.IdTipodevendedor)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("TIPODEVENDEDOR");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("PUEDE_SER2_FK");

                entity.HasIndex(e => e.IdVendedor)
                    .HasName("SEDETALLA_FK");

                entity.Property(e => e.IdTipodevendedor)
                    .HasColumnName("ID_TIPODEVENDEDOR")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.IdVendedor).HasColumnName("ID_VENDEDOR");

                entity.Property(e => e.Tipodevendedor1)
                    .HasColumnName("TIPODEVENDEDOR")
                    .HasColumnType("text");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Tipodevendedor)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_TIPODEVE_PUEDE_SER_USUARIO");

                entity.HasOne(d => d.IdVendedorNavigation)
                    .WithMany(p => p.Tipodevendedor)
                    .HasForeignKey(d => d.IdVendedor)
                    .HasConstraintName("FK_TIPODEVE_SEDETALLA_DETALLED");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("USUARIO");

                entity.HasIndex(e => e.IdDireccion)
                    .HasName("VIVE_FK");

                entity.HasIndex(e => e.IdRol)
                    .HasName("PUEDESER_FK");

                entity.HasIndex(e => e.IdTipodepago)
                    .HasName("REALIZAPAGO_FK");

                entity.HasIndex(e => e.IdTipodevendedor)
                    .HasName("PUEDE_SER_FK");

                entity.HasIndex(e => e.IdVendedor)
                    .HasName("PUEDEREPRESENTAR2_FK");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("ID_USUARIO")
                    .ValueGeneratedNever();

                entity.Property(e => e.ApellidoUsuario)
                    .HasColumnName("APELLIDO_USUARIO")
                    .HasColumnType("text");

                entity.Property(e => e.CorreoUsuario)
                    .HasColumnName("CORREO_USUARIO")
                    .HasColumnType("text");

                entity.Property(e => e.Fechadenacimiento)
                    .HasColumnName("FECHADENACIMIENTO")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdDireccion).HasColumnName("ID_DIRECCION");

                entity.Property(e => e.IdRol).HasColumnName("ID_ROL");

                entity.Property(e => e.IdTipodepago).HasColumnName("ID_TIPODEPAGO");

                entity.Property(e => e.IdTipodevendedor).HasColumnName("ID_TIPODEVENDEDOR");

                entity.Property(e => e.IdVendedor).HasColumnName("ID_VENDEDOR");

                entity.Property(e => e.Nameuser)
                    .HasColumnName("NAMEUSER")
                    .HasColumnType("text");

                entity.Property(e => e.NombreUsuario)
                    .HasColumnName("NOMBRE_USUARIO")
                    .HasColumnType("text");

                entity.Property(e => e.PsswdUsuario)
                    .HasColumnName("PSSWD_USUARIO")
                    .HasColumnType("text");

                entity.Property(e => e.TelefonoUsuario).HasColumnName("TELEFONO_USUARIO");

                entity.HasOne(d => d.IdDireccionNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdDireccion)
                    .HasConstraintName("FK_USUARIO_VIVE_DIRECCIO");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USUARIO_PUEDESER_ROL");

                entity.HasOne(d => d.IdTipodepagoNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdTipodepago)
                    .HasConstraintName("FK_USUARIO_REALIZAPA_TIPODEPA");

                entity.HasOne(d => d.IdTipodevendedorNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdTipodevendedor)
                    .HasConstraintName("FK_USUARIO_PUEDE_SER_TIPODEVE");

                entity.HasOne(d => d.IdVendedorNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdVendedor)
                    .HasConstraintName("FK_USUARIO_PUEDEREPR_DETALLED");
            });
        }
    }
}
