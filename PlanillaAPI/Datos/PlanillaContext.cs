using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PlanillaAPI.Datos
{
    public partial class PlanillaContext : DbContext
    {
        public PlanillaContext()
        {
        }

        public PlanillaContext(DbContextOptions<PlanillaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asistencia> Asistencias { get; set; }
        public virtual DbSet<Departamento> Departamentos { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Puesto> Puestos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-EHA7KUB;Initial Catalog=Planilla;Trusted_connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Asistencia>(entity =>
            {
                entity.HasKey(e => e.Idasistencia)
                    .HasName("PK__asistenc__D186AE722C622F8F");

                entity.ToTable("asistencias");

                entity.Property(e => e.Idasistencia).HasColumnName("idasistencia");

                entity.Property(e => e.EmpleadoId).HasColumnName("empleado_id");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.HasOne(d => d.Empleado)
                    .WithMany(p => p.Asistencia)
                    .HasForeignKey(d => d.EmpleadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_asistencias_empleados_1");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.Iddepartamento)
                    .HasName("PK__departam__AA1019ECE8174CC2");

                entity.ToTable("departamentos");

                entity.Property(e => e.Iddepartamento).HasColumnName("iddepartamento");

                entity.Property(e => e.EmpresaId).HasColumnName("empresa_id");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.ToTable("empleados");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DepartamentoId).HasColumnName("departamento_id");

                entity.Property(e => e.Dpi)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("dpi");

                entity.Property(e => e.EmpresaId).HasColumnName("empresa_id");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.PuestoId).HasColumnName("puesto_id");

                entity.Property(e => e.Salario)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("salario");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.Departamento)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.DepartamentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_empleados_departamentos_1");

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.EmpresaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_empleados_empresas_1");

                entity.HasOne(d => d.Puesto)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.PuestoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_empleados_puestos_1");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.Idempresa)
                    .HasName("PK__empresas__18E1FEAAD6EFDD79");

                entity.ToTable("empresas");

                entity.Property(e => e.Idempresa).HasColumnName("idempresa");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<Puesto>(entity =>
            {
                entity.HasKey(e => e.Idpuesto)
                    .HasName("PK__puestos__7C742D08454B7961");

                entity.ToTable("puestos");

                entity.Property(e => e.Idpuesto).HasColumnName("idpuesto");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario)
                    .HasName("PK__usuarios__080A97437479AA1B");

                entity.ToTable("usuarios");

                entity.Property(e => e.Idusuario).HasColumnName("idusuario");

                entity.Property(e => e.EmpresaId).HasColumnName("empresa_id");

                entity.Property(e => e.Estado).HasColumnName("estado ");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Tipo).HasColumnName("tipo");

                entity.Property(e => e.User)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("user");

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.EmpresaId)
                    .HasConstraintName("fk_usuarios_empresas_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
