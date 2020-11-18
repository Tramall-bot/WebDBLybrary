using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Pages.FilReq
{
    public class StaffFilModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public StaffFilModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get; set; }
        public Position Position { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Position =  _context.Position.First(m => m.ID == id);
            if (Position == null)
            {
                return NotFound();
            }
            Employee = await _context.Employee
                .Include(e => e.Pos).Where(m => m.PosID == Position.ID).ToListAsync();
            return Page();
        }
    }
}
