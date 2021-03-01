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
    public class EditModel : PageModel
    {
        private readonly AppDbContext _ctx;

        public EditModel(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task  OnGet(int id)
        {
            Book = await _ctx.Books.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                // _ctx.Books.Update(Book);
                var BookfromDb = await _ctx.Books.FindAsync(Book.Id);
                BookfromDb.Name = Book.Name;
                BookfromDb.Author = Book.Author;
                BookfromDb.ISBN = Book.ISBN;
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
