using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RentRazor.DbModel
{
    public partial class RentPropertyContext : DbContext
    {
        public RentPropertyContext()
        {
        }

        public RentPropertyContext(DbContextOptions<RentPropertyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AddressOfProperty> AddressOfProperties { get; set; }
        public virtual DbSet<PhotoOfPropert> PhotoOfProperts { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<PropertyType> PropertyTypes { get; set; }
        public virtual DbSet<TagMerge> TagMerges { get; set; }
        public virtual DbSet<TagsOfProperty> TagsOfProperties { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=KOSHKA-O4KOVAYA\\SQLEXPRESS;Database=RentProperty;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<AddressOfProperty>(entity =>
            {
                entity.ToTable("AddressOfProperty");

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<PhotoOfPropert>(entity =>
            {
                entity.ToTable("PhotoOfPropert");

                entity.Property(e => e.Photo).HasColumnType("image");

                entity.HasOne(d => d.AdressNavigation)
                    .WithMany(p => p.PhotoOfProperts)
                    .HasForeignKey(d => d.Adress)
                    .HasConstraintName("FK__PhotoOfPr__Adres__2C3393D0");
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.ToTable("Property");

                entity.Property(e => e.TelephoneNumber)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.AdressNavigation)
                    .WithMany(p => p.Properties)
                    .HasForeignKey(d => d.Adress)
                    .HasConstraintName("FK__Property__Adress__286302EC");

                entity.HasOne(d => d.PropertyTypeNavigation)
                    .WithMany(p => p.Properties)
                    .HasForeignKey(d => d.PropertyType)
                    .HasConstraintName("FK__Property__Proper__29572725");
            });

            modelBuilder.Entity<PropertyType>(entity =>
            {
                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<TagMerge>(entity =>
            {
                entity.ToTable("TagMerge");

                entity.HasOne(d => d.IdOfPropertyNavigation)
                    .WithMany(p => p.TagMerges)
                    .HasForeignKey(d => d.IdOfProperty)
                    .HasConstraintName("FK__TagMerge__IdOfPr__31EC6D26");

                entity.HasOne(d => d.IdOfTagNavigation)
                    .WithMany(p => p.TagMerges)
                    .HasForeignKey(d => d.IdOfTag)
                    .HasConstraintName("FK__TagMerge__IdOfTa__30F848ED");
            });

            modelBuilder.Entity<TagsOfProperty>(entity =>
            {
                entity.ToTable("TagsOfProperty");

                entity.Property(e => e.TagName).HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
