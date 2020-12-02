using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProyectoUME.Core.Domain;

namespace ProyectoUME.Infrastructure.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aspnetroleclaims> Aspnetroleclaims { get; set; }
        public virtual DbSet<Aspnetroles> Aspnetroles { get; set; }
        public virtual DbSet<Aspnetuserclaims> Aspnetuserclaims { get; set; }
        public virtual DbSet<Aspnetuserlogins> Aspnetuserlogins { get; set; }
        public virtual DbSet<Aspnetuserroles> Aspnetuserroles { get; set; }
        public virtual DbSet<Aspnetusers> Aspnetusers { get; set; }
        public virtual DbSet<Aspnetusertokens> Aspnetusertokens { get; set; }
        public virtual DbSet<Documentos> Documentos { get; set; }
        public virtual DbSet<Efmigrationshistory> Efmigrationshistory { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Excusa> Excusa { get; set; }
        public virtual DbSet<IdentityuserString> IdentityuserString { get; set; }
        public virtual DbSet<Jornada> Jornada { get; set; }
        public virtual DbSet<ListaEmpleados> ListaEmpleados { get; set; }
        public virtual DbSet<Permiso> Permiso { get; set; }
        public virtual DbSet<Proyecto> Proyecto { get; set; }
        public virtual DbSet<TurnoLaboral> TurnoLaboral { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseMySQL("database=proyecto ume;server=localhost;port=3306;user id=root;password=");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aspnetroleclaims>(entity =>
            {
                entity.ToTable("aspnetroleclaims");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ClaimType).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ClaimValue).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(127);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Aspnetroleclaims)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId");
            });

            modelBuilder.Entity<Aspnetroles>(entity =>
            {
                entity.ToTable("aspnetroles");

                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(127);

                entity.Property(e => e.ConcurrencyStamp)
                    .HasMaxLength(256)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NormalizedName)
                    .HasMaxLength(256)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Aspnetuserclaims>(entity =>
            {
                entity.ToTable("aspnetuserclaims");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserClaims_UserId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ClaimType).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ClaimValue).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserclaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserClaims_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetuserlogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                    .HasName("PRIMARY");

                entity.ToTable("aspnetuserlogins");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(127);

                entity.Property(e => e.ProviderKey).HasMaxLength(127);

                entity.Property(e => e.ProviderDisplayName).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserlogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetuserroles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PRIMARY");

                entity.ToTable("aspnetuserroles");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_AspNetUserRoles_RoleId");

                entity.Property(e => e.UserId).HasMaxLength(127);

                entity.Property(e => e.RoleId).HasMaxLength(127);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Aspnetuserroles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserroles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetusers>(entity =>
            {
                entity.ToTable("aspnetusers");

                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.AccessFailedCount).HasColumnType("int(11)");

                entity.Property(e => e.ConcurrencyStamp).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NormalizedEmail)
                    .HasMaxLength(256)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NormalizedUserName)
                    .HasMaxLength(256)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PasswordHash).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PhoneNumber).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.SecurityStamp).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UserName)
                    .HasMaxLength(256)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Aspnetusertokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                    .HasName("PRIMARY");

                entity.ToTable("aspnetusertokens");

                entity.Property(e => e.UserId).HasMaxLength(127);

                entity.Property(e => e.LoginProvider).HasMaxLength(127);

                entity.Property(e => e.Name).HasMaxLength(127);

                entity.Property(e => e.Value).HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetusertokens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserTokens_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Documentos>(entity =>
            {
                entity.HasKey(e => e.IdTramite)
                    .HasName("PRIMARY");

                entity.ToTable("documentos");

                entity.Property(e => e.IdTramite)
                    .HasColumnName("Id_tramite")
                    .HasColumnType("int(10)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CertificadoArl)
                    .HasColumnName("Certificado_ARL")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CertificadoEps)
                    .HasColumnName("Certificado_EPS")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CertificadoPension)
                    .HasColumnName("Certificado_Pension")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CursoAlturas)
                    .HasColumnName("Curso_alturas")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.HojaVida)
                    .HasColumnName("Hoja_Vida")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IdTramiteNavigation)
                    .WithOne(p => p.Documentos)
                    .HasForeignKey<Documentos>(d => d.IdTramite)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_IdTramite_IdUsuario");
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.Nit)
                    .HasName("PRIMARY");

                entity.ToTable("empresa");

                entity.Property(e => e.Nit)
                    .HasColumnName("NIT")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Ciudad)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.NombreEmpresa)
                    .IsRequired()
                    .HasColumnName("Nombre_Empresa")
                    .HasMaxLength(20);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Excusa>(entity =>
            {
                entity.HasKey(e => e.IdExcusa)
                    .HasName("PRIMARY");

                entity.ToTable("excusa");

                entity.Property(e => e.IdExcusa)
                    .HasColumnName("idExcusa")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AnexoEvidencia)
                    .IsRequired()
                    .HasColumnName("Anexo_Evidencia")
                    .HasMaxLength(2);

                entity.Property(e => e.Apellido1)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Apellodo2)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Correo)
                    .HasMaxLength(25)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Nombre1)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Nombre2)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<IdentityuserString>(entity =>
            {
                entity.ToTable("identityuser<string>");

                entity.Property(e => e.Id).HasMaxLength(127);

                entity.Property(e => e.AccessFailedCount).HasColumnType("int(11)");

                entity.Property(e => e.ConcurrencyStamp).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Email).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NormalizedEmail).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NormalizedUserName).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PasswordHash).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PhoneNumber).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.SecurityStamp).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UserName).HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Jornada>(entity =>
            {
                entity.HasKey(e => e.IdJornada)
                    .HasName("PRIMARY");

                entity.ToTable("jornada");

                entity.Property(e => e.IdJornada)
                    .HasColumnName("idJornada")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Jornada1)
                    .HasColumnName("Jornada")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<ListaEmpleados>(entity =>
            {
                entity.HasKey(e => e.IdListaEmpleados)
                    .HasName("PRIMARY");

                entity.ToTable("lista_empleados");

                entity.HasIndex(e => e.ProyectoIdProyecto)
                    .HasName("fk_Lista_empleados_Proyecto1_idx");

                entity.Property(e => e.IdListaEmpleados)
                    .HasColumnName("idLista_empleados")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProyectoIdProyecto)
                    .HasColumnName("Proyecto_idProyecto")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.ProyectoIdProyectoNavigation)
                    .WithMany(p => p.ListaEmpleados)
                    .HasForeignKey(d => d.ProyectoIdProyecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Lista_empleados_Proyecto1");
            });

            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.HasKey(e => e.IdPermiso)
                    .HasName("PRIMARY");

                entity.ToTable("permiso");

                entity.Property(e => e.IdPermiso)
                    .HasColumnName("idPermiso")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Apellido1)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Apellido2)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Nombre1)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Nombre2)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.HasKey(e => e.IdProyecto)
                    .HasName("PRIMARY");

                entity.ToTable("proyecto");

                entity.Property(e => e.IdProyecto)
                    .HasColumnName("idProyecto")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DireccionPoyecto)
                    .IsRequired()
                    .HasColumnName("Direccion_Poyecto")
                    .HasMaxLength(30);

                entity.Property(e => e.NumeroEmpleados)
                    .HasColumnName("Numero_Empleados")
                    .HasColumnType("int(3)");

                entity.Property(e => e.PersonaResponsable)
                    .IsRequired()
                    .HasColumnName("Persona_Responsable")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<TurnoLaboral>(entity =>
            {
                entity.HasKey(e => e.IdConsulta)
                    .HasName("PRIMARY");

                entity.ToTable("turno_laboral");

                entity.HasIndex(e => e.JornadaIdJornada)
                    .HasName("fk_Turno_Laboral_Jornada1_idx");

                entity.Property(e => e.IdConsulta)
                    .HasColumnName("idConsulta")
                    .HasColumnType("int(11)");

                entity.Property(e => e.HoraIngreso).HasColumnName("Hora_Ingreso");

                entity.Property(e => e.HoraSalida).HasColumnName("Hora_Salida");

                entity.Property(e => e.JornadaIdJornada)
                    .HasColumnName("Jornada_idJornada")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.JornadaIdJornadaNavigation)
                    .WithMany(p => p.TurnoLaboral)
                    .HasForeignKey(d => d.JornadaIdJornada)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Turno_Laboral_Jornada1");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.AspnetusersId)
                    .HasName("Aspnetusers_Id");

                entity.HasIndex(e => e.EmpresaNit)
                    .HasName("fk_Usuario_Empresa_idx");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("idUsuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AspnetusersId)
                    .HasColumnName("Aspnetusers_Id")
                    .HasMaxLength(257)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Edad).HasColumnType("int(2)");

                entity.Property(e => e.EmpresaNit)
                    .HasColumnName("Empresa_NIT")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PrimerApellido)
                    .IsRequired()
                    .HasColumnName("Primer_Apellido")
                    .HasMaxLength(25);

                entity.Property(e => e.PrimerNombre)
                    .IsRequired()
                    .HasColumnName("Primer_Nombre")
                    .HasMaxLength(10);

                entity.Property(e => e.SegundoApellido)
                    .IsRequired()
                    .HasColumnName("Segundo_Apellido")
                    .HasMaxLength(25);

                entity.Property(e => e.SegundoNombre)
                    .IsRequired()
                    .HasColumnName("Segundo_Nombre")
                    .HasMaxLength(10);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.Aspnetusers)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.AspnetusersId)
                    .HasConstraintName("usuario_ibfk_1");

                entity.HasOne(d => d.EmpresaNitNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.EmpresaNit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Usuario_Empresa");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
