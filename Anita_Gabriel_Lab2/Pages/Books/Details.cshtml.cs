using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Anita_Gabriel_Lab2.Data;
using Anita_Gabriel_Lab2.Models;

namespace Anita_Gabriel_Lab2.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly Anita_Gabriel_Lab2.Data.Anita_Gabriel_Lab2Context _context;

        public DetailsModel(Anita_Gabriel_Lab2.Data.Anita_Gabriel_Lab2Context context)
        {
            _context = context;
        }

        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.Include(b => b.Author).Include(b => b.Publisher).FirstOrDefaultAsync(m => m.ID == id);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                Book = book;
            }
            return Page();
        }
    }
}
