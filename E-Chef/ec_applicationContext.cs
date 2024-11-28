using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace E_Chef
{
    public partial class ec_applicationContext : DbContext
    {
        public ec_applicationContext()
        {
        }

        public ec_applicationContext(DbContextOptions<ec_applicationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Felhasznalok> Felhasznaloks { get; set; } = null!;
        public virtual DbSet<Receptek> Recepteks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=ASUS-HENI;Database=ec_application;Trusted_Connection=Yes");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Felhasznalok>(entity =>
            {
                entity.ToTable("felhasznalok");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Felhasznalonev)
                    .HasMaxLength(50)
                    .HasColumnName("felhasznalonev");

                entity.Property(e => e.Jelszo)
                    .HasMaxLength(50)
                    .HasColumnName("jelszo");
            });

            modelBuilder.Entity<Receptek>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("receptek");

                entity.Property(e => e.Alma).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Csoki).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Cukor).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Desszertnev)
                    .HasMaxLength(10)
                    .HasColumnName("desszertnev")
                    .IsFixedLength();

                entity.Property(e => e.Dió).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Eper).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Kakaó).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Karamell).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Keksz).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Kókusz).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Lekvár).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Liszt).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Mascarpone).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Méz).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Olaj).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Oreó).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Recept).HasColumnName("recept");

                entity.Property(e => e.Szilva).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Tej).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Tejszín).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Tojás).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Túró).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Vaj).HasColumnType("numeric(18, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
