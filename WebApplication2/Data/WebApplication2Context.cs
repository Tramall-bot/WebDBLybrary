using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebDBLybrary.Models;

namespace WebApplication2.Data
{
    public class WebApplication2Context : DbContext
    {
        public WebApplication2Context (DbContextOptions<WebApplication2Context> options)
            : base(options)
        {
        }

        public DbSet<WebDBLybrary.Models.Book> Book { get; set; }

        public DbSet<WebDBLybrary.Models.Genre> Genre { get; set; }

        public DbSet<WebDBLybrary.Models.Employee> Employee { get; set; }

        public DbSet<WebDBLybrary.Models.Position> Position { get; set; }

        public DbSet<WebDBLybrary.Models.Publisher> Publisher { get; set; }

        public DbSet<WebDBLybrary.Models.Reader> Reader { get; set; }

        public DbSet<WebDBLybrary.Models.ReturnedBook> ReturnedBook { get; set; }
    }
}
