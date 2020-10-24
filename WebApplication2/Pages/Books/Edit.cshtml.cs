using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebDBLybrary.Models;

namespace WebApplication2.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public EditModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; }
        public List<SelectListItem> Genre { get; set; }
        public List<SelectListItem> Publisher { get; set; }
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Book
                .Include(b => b.Gen)
                .Include(b => b.Pub).FirstOrDefaultAsync(m => m.ID == id);

            if (Book == null)
            {
                return NotFound();
            }
           ViewData["GenreId"] = _context.Publisher.Select(p =>
                 new SelectListItem
                 {
                     Value = p.ID.ToString(),
                     Text = p.PubName
                 }).ToList();
            ViewData["PublisherID"] = _context.Genre.Select(p =>
                 new SelectListItem
                 {
                     Value = p.ID.ToString(),
                     Text = p.GenName
                 }).ToList();
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(Book.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookExists(long id)
        {
            return _context.Book.Any(e => e.ID == id);
        }
    }
}
