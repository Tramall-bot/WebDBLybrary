using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Pages.ReturnedBooks
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public CreateModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }
        public List<SelectListItem> Book { get; set; }
        public List<SelectListItem> Employee { get; set; }
        public List<SelectListItem> Reader { get; set; }
        public IActionResult OnGet()
        {
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

        [BindProperty]
        public ReturnedBook ReturnedBook { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ReturnedBook.Add(ReturnedBook);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
