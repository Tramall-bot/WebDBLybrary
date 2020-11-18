using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication2.Pages.FilReq
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public IndexModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }
        public List<SelectListItem> SelPos { get; set; }
        public List<SelectListItem> SelPub { get; set; }
        public List<SelectListItem> SelAuthor { get; set; }
        public List<SelectListItem> SelDate { get; set; }
        public List<SelectListItem> SelOnHand { get; set; }
        public List<SelectListItem> SelRead { get; set; }

        public void OnGet()
        {
            SelPos = _context.Position.Select(p => new SelectListItem
            {
                Value = p.ID.ToString(),
                Text = p.PosName
            }).ToList();
            SelPub = _context.Publisher.Select(p => new SelectListItem
            {
                Value = p.ID.ToString(),
                Text = p.PubName
            }).ToList();
            SelAuthor = _context.Book.Select(p => new SelectListItem
            {
                Value = p.ID.ToString(),
                Text = p.BkAuthor
            }).ToList();
            SelDate = _context.Book.Select(p => new SelectListItem
            {
                Value = p.ID.ToString(),
                Text = p.BkRealiseDate.ToString()
            }).ToList();
            SelOnHand = new List<SelectListItem>
            {
            new SelectListItem
            {
                Value = "False",
                Text = "На руках"
            },
             new SelectListItem
                {
                    Value = "True",
                    Text = "Возвращённые"
                }};
            SelRead = _context.Reader.Select(p => new SelectListItem
            {
                Value = p.ID.ToString(),
                Text = p.RdFullName
            }).ToList();
        }
    }
}
