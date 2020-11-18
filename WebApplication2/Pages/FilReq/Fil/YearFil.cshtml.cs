using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Pages.FilReq.Fil
{
    public class YearFilModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public YearFilModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        public Book Book { get; set; }
        public IList<Book> Books { get; set; }

        public IList<Genre> Genre { get; set; }
        public IList<Publisher> Publisher { get; set; }
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Book = _context.Book
                .Include(b => b.Gen)
                .Include(b => b.Pub).First(m => m.ID == id);
            if (Book == null)
            {
                return NotFound();
            }
            Books = await _context.Book
        .Include(b => b.Gen)
        .Include(b => b.Pub).Where(m => m.ID == Book.ID).ToListAsync();

            Genre = await _context.Genre.Where(m =>m.ID == Book.ID).ToListAsync();
            Publisher = await _context.Publisher.Where(m => m.ID == Book.ID).ToListAsync();
            return Page();
        }
    }
}
