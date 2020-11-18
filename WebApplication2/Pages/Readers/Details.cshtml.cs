using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Pages.Readers
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public DetailsModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        public Reader Reader { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Reader = await _context.Reader.FirstOrDefaultAsync(m => m.ID == id);

            if (Reader == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
