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
    public class PubFilModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public PubFilModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; }
        public IList<Genre> Genre { get; set; }
        public Publisher Publisher { get; set; }
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Publisher =  _context.Publisher.First(m => m.ID == id);
            if (Publisher == null)
            {
                return NotFound();
            }
            Book = await _context.Book
                .Include(b => b.Gen)
                .Include(b => b.Pub).Where(m => m.ID == Publisher.ID).ToListAsync();
            Genre = await _context.Genre.Where(m => m.ID == Publisher.ID).ToListAsync();
            return Page();
        }
    }
}
