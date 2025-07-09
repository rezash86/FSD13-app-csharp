using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fsd13_project7_codefirst
{
    public class MyDbcontext :DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Post> posts {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Database=FSD-test-codefirst.mdf;Integrated Security=True;Connect Timeout=30");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasOne(a => a.Employee)
                .WithMany(e => e.addresses)
                .HasForeignKey(a => a.EmployeeId);

            modelBuilder.Entity<Blog>()
                .HasMany(e => e.Posts)
                .WithOne(e => e.Blog)
                .HasForeignKey(e => e.BlogId)
                .IsRequired();
        }
    }
}
