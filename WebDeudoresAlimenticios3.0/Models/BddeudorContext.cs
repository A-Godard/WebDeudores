using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebDeudoresAlimenticios3._0.Models;

public partial class BddeudorContext : DbContext
{
    public BddeudorContext()
    {
    }

    public BddeudorContext(DbContextOptions<BddeudorContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AbogadoAsociado> AbogadoAsociados { get; set; }

    public virtual DbSet<AbogadoAsociadoComb> AbogadoAsociadoCombs { get; set; }

    public virtual DbSet<Deudor> Deudors { get; set; }

    public virtual DbSet<DeudorHijo> DeudorHijos { get; set; }

    public virtual DbSet<DeudorHijoComb> DeudorHijoCombs { get; set; }

    public virtual DbSet<FamiliarDeudor> FamiliarDeudors { get; set; }

    public virtual DbSet<FamiliarDeudorComb> FamiliarDeudorCombs { get; set; }

    public virtual DbSet<ListaAbogado> ListaAbogados { get; set; }

    public virtual DbSet<ListaDeudorHijo> ListaDeudorHijos { get; set; }

    public virtual DbSet<ListaFamiliare> ListaFamiliares { get; set; }

    public virtual DbSet<ListaTutor> ListaTutors { get; set; }

    public virtual DbSet<TutorLegal> TutorLegals { get; set; }

    public virtual DbSet<TutorLegalComb> TutorLegalCombs { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
  //      => optionsBuilder.UseSqlServer("server=localhost; database=BDDEUDOR; integrated security=true; TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AbogadoAsociado>(entity =>
        {
            entity.HasKey(e => e.IdAbogado).HasName("PK__AbogadoA__9C2E1F074861F089");

            entity.ToTable("AbogadoAsociado");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Apellidos)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Cedula)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTutorNavigation).WithMany(p => p.AbogadoAsociados)
                .HasForeignKey(d => d.IdTutor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AbogadoAs__IdTut__4D94879B");
        });

        modelBuilder.Entity<AbogadoAsociadoComb>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AbogadoA__3214EC27F8674B9E");

            entity.ToTable("AbogadoAsociadoComb");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ApellidosAbogado)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Cedula)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.NombreAbogado)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Deudor>(entity =>
        {
            entity.HasKey(e => e.IdDeudor).HasName("PK__Deudor__0A24A454F9E72E47");

            entity.ToTable("Deudor");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Apellidos)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Cedula)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DeudorHijo>(entity =>
        {
            entity.HasKey(e => e.IdHijoDeudor).HasName("PK__DeudorHi__50EFE5BFE1F08DA1");

            entity.ToTable("DeudorHijo");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Correo)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.IdDeudorNavigation).WithMany(p => p.DeudorHijos)
                .HasForeignKey(d => d.IdDeudor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DeudorHij__IdDeu__412EB0B6");
        });

        modelBuilder.Entity<DeudorHijoComb>(entity =>
        {
            entity.HasKey(e => e.IdHijoDeudor).HasName("PK__DeudorHi__50EFE5BF9CE3FCB9");

            entity.ToTable("DeudorHijoComb");

            entity.Property(e => e.Correo)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.NombreHijo)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.PadreDeudor)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FamiliarDeudor>(entity =>
        {
            entity.HasKey(e => e.IdFamiliarDeudor).HasName("PK__Familiar__E93C9D3CA67EC8F2");

            entity.ToTable("FamiliarDeudor");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.ApellidosFamiliar)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Cedula)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.NombresFamiliar)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Parentesco)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.IdDeudorNavigation).WithMany(p => p.FamiliarDeudors)
                .HasForeignKey(d => d.IdDeudor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FamiliarD__IdDeu__3D5E1FD2");
        });

        modelBuilder.Entity<FamiliarDeudorComb>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Familiar__3214EC27A514C1C5");

            entity.ToTable("FamiliarDeudorComb");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ApellidoDeudor)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Cedula)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.NombreDeudor)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.NombreFamiliarDeudor)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Parentesco)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ListaAbogado>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ListaAbogado");

            entity.Property(e => e.ApellidoAbogado)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Cedula)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NombreAbogado)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.NombreTutor)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ListaDeudorHijo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ListaDeudorHijo");

            entity.Property(e => e.Correo)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.NombreHijo)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.PadreDeudor)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ListaFamiliare>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ListaFamiliares");

            entity.Property(e => e.Activo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoDeudor)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Apellido_Deudor");
            entity.Property(e => e.ApellidosFamiliar)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Cedula)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NombreDeudor)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Nombre_Deudor");
            entity.Property(e => e.NombreFamiliarDeudor)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Nombre_Familiar_Deudor");
            entity.Property(e => e.Parentesco)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ListaTutor>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ListaTutor");

            entity.Property(e => e.ApellidoTutor)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Cedula)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NombreHijo)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.NombreTutor)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TutorLegal>(entity =>
        {
            entity.HasKey(e => e.IdTutor).HasName("PK__TutorLeg__C168D3887C69F46E");

            entity.ToTable("TutorLegal");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Apellidos)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Cedula)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.IdHijoDeudorNavigation).WithMany(p => p.TutorLegals)
                .HasForeignKey(d => d.IdHijoDeudor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TutorLega__IdHij__45F365D3");
        });

        modelBuilder.Entity<TutorLegalComb>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TutorLeg__3214EC2708A5008D");

            entity.ToTable("TutorLegalComb");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ApellidosTutor)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Cedula)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.NombreHijo)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.NombreTutor)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.ToTable("Usuario");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Apellidos)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Contraseña)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
