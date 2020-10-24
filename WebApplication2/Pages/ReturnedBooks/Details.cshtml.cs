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
    public class DetailsModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public DetailsModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        public ReturnedBook ReturnedBook { get; set; }

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

            if (ReturnedBook == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
