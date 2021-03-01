using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Data;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookFolder
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _ctx;

        public CreateModel(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        [BindProperty]
        public Book Book { get; set; }


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _ctx.Books.AddAsync(Book);
                await _ctx.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
