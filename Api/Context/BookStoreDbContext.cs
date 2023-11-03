using Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Context;

public partial class BookStoreDbContext : DbContext
{
   public BookStoreDbContext()
   {
   }

   public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
      : base(options)
   {
   }

   public virtual DbSet<Author> Authors { get; set; }

   public virtual DbSet<Book> Books { get; set; }

   public virtual DbSet<Publisher> Publishers { get; set; }

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
      if (!optionsBuilder.IsConfigured)
      {
         var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

         var configuration = builder.Build();
         var connectionString = configuration.GetConnectionString("BookStore");
         optionsBuilder.UseSqlServer(connectionString);
      }
   }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookStoreDbContext).Assembly);

      base.OnModelCreating(modelBuilder);

      // modelBuilder.Entity<Author>(entity =>
      // {
      //     entity.HasKey(e => e.Id).HasName("PK_Authors");
      //
      //     entity.ToTable("Author");
      //
      //     entity.HasIndex(e => e.Name, "IX_Authors_Name");
      //
      //     entity.Property(e => e.Name)
      //         .IsRequired()
      //         .HasMaxLength(50);
      //     entity.Property(e => e.Nationality)
      //         .IsRequired()
      //         .HasMaxLength(50);
      // });
   }
}