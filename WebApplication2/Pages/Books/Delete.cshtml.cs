using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Pages.Books
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public DeleteModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; }
        public Genre Genre { get; set; }
        public Publisher Publisher { get; set; }
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Book
                .Include(b => b.Gen)
                .Include(b => b.Pub).FirstOrDefaultAsync(m => m.ID == id);
            Genre = await _context.Genre.FirstOrDefaultAsync(m => m.ID == Book.GenreId);
            Publisher = await _context.Publisher.FirstOrDefaultAsync(m => m.ID == Book.GenreId);
            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Book.FindAsync(id);

            if (Book != null)
            {
                _context.Book.Remove(Book);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
