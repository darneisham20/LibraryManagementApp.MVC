using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementApp.MVC.Data;

public partial class LibraryManagementDbContext : DbContext
{
    public LibraryManagementDbContext(DbContextOptions<LibraryManagementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BooksFk> BooksFks { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Authors__3214EC0754D0CD72");

            entity.Property(e => e.AboutAuthor).HasMaxLength(500);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Books__3214EC079BF99CBE");

            entity.Property(e => e.Author).HasMaxLength(50);
            entity.Property(e => e.BookTitle).HasMaxLength(50);
            entity.Property(e => e.Genres).HasMaxLength(100);
            entity.Property(e => e.OriginallyPublished).HasColumnType("date");
            entity.Property(e => e.SeriesName).HasMaxLength(50);
        });

        modelBuilder.Entity<BooksFk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BooksFK__3214EC07A0E61E89");

            entity.ToTable("BooksFK");

            entity.Property(e => e.Genre).HasMaxLength(100);
            entity.Property(e => e.OriginalTitle).HasMaxLength(50);
            entity.Property(e => e.PublishDate).HasColumnType("date");
            entity.Property(e => e.SeriesTitle).HasMaxLength(50);

            entity.HasOne(d => d.Author).WithMany(p => p.BooksFks)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK__BooksFK__AuthorI__49C3F6B7");
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Publishe__3214EC0747DE22C9");

            entity.Property(e => e.Company).HasMaxLength(50);
            entity.Property(e => e.Genres).HasMaxLength(100);
            entity.Property(e => e.Location).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
