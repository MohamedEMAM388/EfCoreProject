using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfProject.Models;
namespace EfProject.Contexts
{
    public class LibraryManagementSystemContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer("Server = .; Database = LibraryManagementSystem; Trusted_Connection = true; TrustServerCertificate=True");
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MemberLoans> MemberLoans { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Fine> Fines { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibraryManagementSystemContext).Assembly);
        }
    }
}
