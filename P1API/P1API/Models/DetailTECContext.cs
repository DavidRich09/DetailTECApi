using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace P1API.Models
{
    public partial class DetailTECContext : DbContext
    {
        public DetailTECContext()
        {
        }

        public DetailTECContext(DbContextOptions<DetailTECContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Citum> Cita { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<DirCliente> DirClientes { get; set; } = null!;
        public virtual DbSet<Lavado> Lavados { get; set; } = null!;
        public virtual DbSet<PersonalLavado> PersonalLavados { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Proveedor> Proveedors { get; set; } = null!;
        public virtual DbSet<ProveedorProducto> ProveedorProductos { get; set; } = null!;
        public virtual DbSet<Sucursal> Sucursals { get; set; } = null!;
        public virtual DbSet<TelCliente> TelClientes { get; set; } = null!;
        public virtual DbSet<Trabajador> Trabajadors { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=localhost\\SQLEXPRESS; database=DetailTEC; integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Citum>(entity =>
            {
                entity.HasKey(e => new { e.PlacaVehiculo, e.Fecha })
                    .HasName("PK_Citas");

                entity.ToTable("cita", "lavacar");

                entity.Property(e => e.PlacaVehiculo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("placa_vehiculo");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.CedCliente).HasColumnName("ced_cliente");

                entity.Property(e => e.CedEmpleado).HasColumnName("ced_empleado");

                entity.Property(e => e.Sucursal)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sucursal");

                entity.Property(e => e.TipoLavado)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("tipo_lavado");

                entity.HasOne(d => d.CedClienteNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.CedCliente)
                    .HasConstraintName("FK_ClienteCorr");

                entity.HasOne(d => d.CedEmpleadoNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.CedEmpleado)
                    .HasConstraintName("FK_ResponsableCita");

                entity.HasOne(d => d.SucursalNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.Sucursal)
                    .HasConstraintName("FK_SucursalCita");

                entity.HasOne(d => d.TipoLavadoNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.TipoLavado)
                    .HasConstraintName("FK_tipolavadocita");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Cedula)
                    .HasName("PK__cliente__415B7BE48ABCF431");

                entity.ToTable("cliente", "lavacar");

                entity.HasIndex(e => e.Usuario, "UQ__cliente__9AFF8FC602628F81")
                    .IsUnique();

                entity.Property(e => e.Cedula)
                    .ValueGeneratedNever()
                    .HasColumnName("cedula");

                entity.Property(e => e.CPassword)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("c_password");

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Puntos).HasColumnName("puntos");

                entity.Property(e => e.PuntosRedimidos).HasColumnName("puntos_redimidos");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("usuario");
            });

            modelBuilder.Entity<DirCliente>(entity =>
            {
                entity.HasKey(e => new { e.Direccion, e.CedCliente })
                    .HasName("PK_dirsc");

                entity.ToTable("dir_cliente", "lavacar");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(225)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.CedCliente).HasColumnName("ced_cliente");

                entity.HasOne(d => d.CedClienteNavigation)
                    .WithMany(p => p.DirClientes)
                    .HasForeignKey(d => d.CedCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dirs_clientes");
            });

            modelBuilder.Entity<Lavado>(entity =>
            {
                entity.HasKey(e => e.TipoLavado)
                    .HasName("PK__lavado__170DE4AA2526558F");

                entity.ToTable("lavado", "lavacar");

                entity.Property(e => e.TipoLavado)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("tipo_lavado");

                entity.Property(e => e.Costo).HasColumnName("costo");

                entity.Property(e => e.Duracion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("duracion");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.Property(e => e.PuntosOtorga).HasColumnName("puntos_otorga");

                entity.Property(e => e.PuntosRedimir).HasColumnName("puntos_redimir");
            });

            modelBuilder.Entity<PersonalLavado>(entity =>
            {
                entity.HasKey(e => new { e.TipoLavado, e.Rol })
                    .HasName("PK_PersonalLavado");

                entity.ToTable("personal_lavado", "lavacar");

                entity.Property(e => e.TipoLavado)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("tipo_lavado");

                entity.Property(e => e.Rol)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("rol");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.HasOne(d => d.TipoLavadoNavigation)
                    .WithMany(p => p.PersonalLavados)
                    .HasForeignKey(d => d.TipoLavado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolLavado");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => new { e.Nombre, e.Marca })
                    .HasName("PK_Productos");

                entity.ToTable("producto", "lavacar");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Marca)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("marca");

                entity.Property(e => e.Costo).HasColumnName("costo");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.CedJuridica)
                    .HasName("PK__proveedo__E9A100CE1E8FBC8B");

                entity.ToTable("proveedor", "lavacar");

                entity.Property(e => e.CedJuridica)
                    .ValueGeneratedNever()
                    .HasColumnName("ced_juridica");

                entity.Property(e => e.Contacto).HasColumnName("contacto");

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(225)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<ProveedorProducto>(entity =>
            {
                entity.HasKey(e => new { e.Nombre, e.Marca, e.CedProveedor })
                    .HasName("PK_ProvProd");

                entity.ToTable("proveedor_producto", "lavacar");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Marca)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("marca");

                entity.Property(e => e.CedProveedor).HasColumnName("ced_proveedor");

                entity.HasOne(d => d.CedProveedorNavigation)
                    .WithMany(p => p.ProveedorProductos)
                    .HasForeignKey(d => d.CedProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProvProd");
            });

            modelBuilder.Entity<Sucursal>(entity =>
            {
                entity.HasKey(e => e.Nombre)
                    .HasName("PK__sucursal__72AFBCC7752228C4");

                entity.ToTable("sucursal", "lavacar");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Apertura)
                    .HasColumnType("date")
                    .HasColumnName("apertura");

                entity.Property(e => e.Canton)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("canton");

                entity.Property(e => e.CedGerente).HasColumnName("ced_gerente");

                entity.Property(e => e.Distrito)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("distrito");

                entity.Property(e => e.InicioGerente)
                    .HasColumnType("date")
                    .HasColumnName("inicio_gerente");

                entity.Property(e => e.Provincia)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("provincia");

                entity.Property(e => e.Telefono).HasColumnName("telefono");

                entity.HasOne(d => d.CedGerenteNavigation)
                    .WithMany(p => p.Sucursals)
                    .HasForeignKey(d => d.CedGerente)
                    .HasConstraintName("FK_SucursalMan");
            });

            modelBuilder.Entity<TelCliente>(entity =>
            {
                entity.HasKey(e => new { e.Telefono, e.CedCliente })
                    .HasName("PK_telsc");

                entity.ToTable("tel_cliente", "lavacar");

                entity.Property(e => e.Telefono).HasColumnName("telefono");

                entity.Property(e => e.CedCliente).HasColumnName("ced_cliente");

                entity.HasOne(d => d.CedClienteNavigation)
                    .WithMany(p => p.TelClientes)
                    .HasForeignKey(d => d.CedCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tels_clientes");
            });

            modelBuilder.Entity<Trabajador>(entity =>
            {
                entity.HasKey(e => e.Cedula)
                    .HasName("PK__Trabajad__415B7BE4F1D6D62F");

                entity.ToTable("Trabajador", "lavacar");

                entity.Property(e => e.Cedula)
                    .ValueGeneratedNever()
                    .HasColumnName("cedula");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.Ingreso)
                    .HasColumnType("date")
                    .HasColumnName("ingreso");

                entity.Property(e => e.Nacimiento)
                    .HasColumnType("date")
                    .HasColumnName("nacimiento");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Rol)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("rol");

                entity.Property(e => e.TPago)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("t_pago");

                entity.Property(e => e.TPassword)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("t_password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
