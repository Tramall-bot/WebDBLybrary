using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
namespace WebApplication2.Data
{
    public class WebApplication2Context : DbContext
    {
        public WebApplication2Context(DbContextOptions<WebApplication2Context> options)
            : base(options)
        {
        }

        public DbSet<WebApplication2.Models.Book> Book { get; set; }

        public DbSet<WebApplication2.Models.Genre> Genre { get; set; }

        public DbSet<WebApplication2.Models.Employee> Employee { get; set; }

        public DbSet<WebApplication2.Models.Position> Position { get; set; }

        public DbSet<WebApplication2.Models.Publisher> Publisher { get; set; }

        public DbSet<WebApplication2.Models.Reader> Reader { get; set; }

        public DbSet<WebApplication2.Models.ReturnedBook> ReturnedBook { get; set; }
    }
}