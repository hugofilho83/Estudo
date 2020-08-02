using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RestApiMySQLNetCore31.Models
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

        public virtual DbSet<Changelog> Changelog { get; set; }
        public virtual DbSet<Persons> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("Server=localhost;port=3306;user=root;password=hf@1983;database=restapi");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Changelog>(entity =>
            {
                entity.ToTable("changelog");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Checksum)
                    .HasColumnName("checksum")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.InstalledBy)
                    .IsRequired()
                    .HasColumnName("installed_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InstalledOn)
                    .HasColumnName("installed_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Success)
                    .HasColumnName("success")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Persons>(entity =>
            {
                entity.ToTable("persons");

                entity.Property(e => e.Id).HasColumnType("bigint(20)");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
