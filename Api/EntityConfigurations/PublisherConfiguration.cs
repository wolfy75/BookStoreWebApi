using Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace src.EntityConfigurations;

public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
{
   public void Configure(EntityTypeBuilder<Publisher> builder)
   {
      builder.HasKey(e => e.Id).HasName("PK_Publishers");

      builder.ToTable("Publisher");

      builder.Property(e => e.Name)
         .IsRequired()
         .HasMaxLength(50);
   }
}