using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Pages.FilReq.Req
{
    public class CatalogModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public CatalogModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; }
        public IList<Genre> Genre { get; set; }
        public IList<Publisher> Publisher { get; set; }
        public async Task OnGetAsync()
        {
            Book = await _context.Book
                .Include(b => b.Gen)
                .Include(b => b.Pub).ToListAsync();
            Genre = await _context.Genre.ToListAsync();
            Publisher = await _context.Publisher.ToListAsync();

        }
    }
}
