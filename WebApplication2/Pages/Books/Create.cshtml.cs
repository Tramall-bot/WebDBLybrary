﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public CreateModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        public List<SelectListItem>  Genre { get; set; }
        public List<SelectListItem> Publisher { get; set; }
        public IActionResult OnGet()
        {
        ViewData["GenreId"] = _context.Genre.Select(p =>
                 new SelectListItem
                 {
                     Value = p.ID.ToString(),
                     Text = p.GenName
                 }).ToList(); 
        ViewData["PublisherID"] = _context.Publisher.Select(p =>
                 new SelectListItem
                 {
                     Value = p.ID.ToString(),
                     Text = p.PubName
                 }).ToList();
            return Page();
         }

        [BindProperty]
        public Book Book { get; set; }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
