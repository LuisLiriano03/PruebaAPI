using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiPrueba.Models
{
    public partial class APIBDContext : DbContext
    {
        public APIBDContext()
        {
        }

        public APIBDContext(DbContextOptions<APIBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumno> Alumnos { get; set; } = null!;
        public virtual DbSet<Aula> Aulas { get; set; } = null!;
        public virtual DbSet<Profesore> Profesores { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.HasKey(e => e.Idalumnos)
                    .HasName("PK__ALUMNO__4B283F184D0D2458");

                entity.ToTable("ALUMNO");

                entity.Property(e => e.ApellidoMaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Calle)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Genero)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LugarDeNacimiento)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nacionalidad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroDeCalle)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroDeTelefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Aula>(entity =>
            {
                entity.HasKey(e => e.Idaulas)
                    .HasName("PK__AULA__92EE6F7E90B3550B");

                entity.ToTable("AULA");

                entity.Property(e => e.Alumnos)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Profesor)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Profesore>(entity =>
            {
                entity.HasKey(e => e.Idempleado)
                    .HasName("PK__PROFESOR__B07D5AC54C373D2B");

                entity.ToTable("PROFESORES");

                entity.Property(e => e.Activo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DepartamentoEnseñar)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoCivil)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Genero)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LugarDeNacimiento)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nacionalidad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCompleto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
