using Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace src.EntityConfigurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
   public void Configure(EntityTypeBuilder<Book> builder)
   {
      builder.HasKey(e => e.Id).HasName("PK_Books");

      builder.ToTable("Book");

      builder.HasIndex(e => e.Title, "IX_Books_Title");

      builder.Property(e => e.DateOfPublish).HasColumnType("date");
      builder.Property(e => e.Title)
         .IsRequired()
         .HasMaxLength(50);

      builder.HasOne(d => d.Publisher).WithMany(p => p.Books)
         .HasForeignKey(d => d.PublisherId)
         .OnDelete(DeleteBehavior.ClientSetNull)
         .HasConstraintName("FK_Books_Publishers");

      builder.HasMany(d => d.Authors).WithMany(p => p.Books)
         .UsingEntity<Dictionary<string, object>>(
            "AuthorBook",
            r => r.HasOne<Author>().WithMany()
               .HasForeignKey("AuthorId")
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_BookToAuthor_Authors"),
            l => l.HasOne<Book>().WithMany()
               .HasForeignKey("BookId")
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_BookToAuthor_Books"),
            j =>
            {
               j.HasKey("BookId", "AuthorId");
               j.ToTable("AuthorBook");
            });
   }
}