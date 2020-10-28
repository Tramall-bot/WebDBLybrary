using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebDBLybrary.Models;

namespace WebApplication2.Pages.ReturnedBooks
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public DeleteModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public ReturnedBook ReturnedBook { get; set; }
        public Book Book { get; set; }
        public Reader Reader { get; set; }
        public Employee Employee { get; set; }
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ReturnedBook = await _context.ReturnedBook
                .Include(r => r.Bk)
                .Include(r => r.Emp)
                .Include(r => r.Rd).FirstOrDefaultAsync(m => m.ID == id);
            Book = await _context.Book.FirstOrDefaultAsync(m => m.ID == ReturnedBook.BkId);
            Reader = await _context.Reader.FirstOrDefaultAsync(m => m.ID == ReturnedBook.RdId);
            Employee = await _context.Employee.FirstOrDefaultAsync(m => m.ID == ReturnedBook.EmpId);
            if (ReturnedBook == null)
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

            ReturnedBook = await _context.ReturnedBook.FindAsync(id);

            if (ReturnedBook != null)
            {
                _context.ReturnedBook.Remove(ReturnedBook);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
