using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MacAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MacAPI.Data
{
public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions dbContextOptions) 
    : base(dbContextOptions)
    {
        
    }
    
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasMany(b => b.Authors)
            .WithMany(a => a.Books);
    }
}
}