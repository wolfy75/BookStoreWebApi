using Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace src.EntityConfigurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
   public void Configure(EntityTypeBuilder<Author> builder)
   {
      builder.HasKey(e => e.Id).HasName("PK_Authors");

      builder.ToTable("Author");

      builder.HasIndex(e => e.Name, "IX_Authors_Name");

      builder.Property(e => e.Name)
         .IsRequired()
         .HasMaxLength(50);
      builder.Property(e => e.Nationality)
         .IsRequired()
         .HasMaxLength(50);
   }
}