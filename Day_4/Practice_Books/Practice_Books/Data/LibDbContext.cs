using Practice_Books.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;

namespace Practice_Books.Data
{
    public class LibDbContext : DbContext
    {

        public LibDbContext(DbContextOptions<LibDbContext> options) : base(options)
        {
        }

        public DbSet<Books> Book { get; set; }
        public DbSet<Department> Department { get; set; }


    }
}
