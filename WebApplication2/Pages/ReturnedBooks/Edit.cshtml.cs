using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Pages.ReturnedBooks
{
    public class EditModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public EditModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public ReturnedBook ReturnedBook { get; set; }
        public List<SelectListItem> Book { get; set; }
        public List<SelectListItem> Employee { get; set; }
        public List<SelectListItem> Reader { get; set; }
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
           ViewData["BkId"] = _context.Book.Select(p =>
                new SelectListItem
                {
                    Value = p.ID.ToString(),
                    Text = p.BkName
                }).ToList();
            ViewData["EmpId"] = _context.Employee.Select(p =>
                 new SelectListItem
                 {
                     Value = p.ID.ToString(),
                     Text = p.EmpFullName
                 }).ToList();
            ViewData["RdId"] = _context.Reader.Select(p =>
                  new SelectListItem
                  {
                      Value = p.ID.ToString(),
                      Text = p.RdFullName
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

            _context.Attach(ReturnedBook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReturnedBookExists(ReturnedBook.ID))
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

        private bool ReturnedBookExists(long id)
        {
            return _context.ReturnedBook.Any(e => e.ID == id);
        }
    }
}
