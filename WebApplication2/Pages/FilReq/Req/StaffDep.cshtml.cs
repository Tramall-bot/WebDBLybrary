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
    public class StaffDepModel : PageModel
    {

            private readonly WebApplication2.Data.WebApplication2Context _context;

            public StaffDepModel(WebApplication2.Data.WebApplication2Context context)
            {
                _context = context;
            }

            public IList<Employee> Employee { get; set; }
            public IList<Position> Position { get; set; }

            public async Task OnGetAsync()
            {
                Employee = await _context.Employee
                    .Include(e => e.Pos).ToListAsync();
                Position = await _context.Position.ToListAsync();
            }
        
    }
}
