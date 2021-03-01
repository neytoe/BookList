using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Data;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.BookFolder
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _ctx;

        public IndexModel(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Book> Books { get; set; }

        public async Task OnGet()
        {
            Books = await  _ctx.Books.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = await _ctx.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            };
            _ctx.Books.Remove(book);
            await _ctx.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
