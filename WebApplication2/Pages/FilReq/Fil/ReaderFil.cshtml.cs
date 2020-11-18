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
    public class ReaderFilModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public ReaderFilModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        public IList<ReturnedBook> ReturnedBook { get; set; }
        public IList<Book> Book { get; set; }
        public IList<Employee> Employee { get; set; }
        public Reader Reader { get; set; }
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Reader =  _context.Reader.First(m => m.ID == id);
            if (Reader == null)
            {
                return NotFound();
            }
            ReturnedBook = await _context.ReturnedBook
                .Include(r => r.Bk)
                .Include(r => r.Emp)
                .Include(r => r.Rd).Where(m => m.RdId == Reader.ID).ToListAsync();
            Book = await _context.Book.ToListAsync();
            Employee = await _context.Employee.ToListAsync();
            return Page();
        }
    }
}
