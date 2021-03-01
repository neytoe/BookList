using BookListRazor.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly AppDbContext _ctx;

        public BookController(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll ()
        {
            return Json(new { data = await _ctx.Books.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var bookFromDb = await _ctx.Books.FirstOrDefaultAsync(b => b.Id == id);
            if(bookFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _ctx.Books.Remove(bookFromDb);
            await _ctx.SaveChangesAsync();
            return Json(new { success = true, message = "Delete Successful" });
        }
    }
}
