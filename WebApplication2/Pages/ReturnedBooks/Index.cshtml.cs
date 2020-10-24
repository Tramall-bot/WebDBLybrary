﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public IndexModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        public IList<ReturnedBook> ReturnedBook { get;set; }
        public IList<Book> Book { get; set; }
        public IList<Employee> Employee { get; set; }
        public IList<Reader> Reader { get; set; }
        public async Task OnGetAsync()
        {
            ReturnedBook = await _context.ReturnedBook
                .Include(r => r.Bk)
                .Include(r => r.Emp)
                .Include(r => r.Rd).ToListAsync();
            Book = await _context.Book.ToListAsync();
            Employee = await _context.Employee.ToListAsync();
            Reader = await _context.Reader.ToListAsync();
        }
    }
}