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
    public class IndexModel : PageModel
    {
        private readonly Anita_Gabriel_Lab2.Data.Anita_Gabriel_Lab2Context _context;

        public IndexModel(Anita_Gabriel_Lab2.Data.Anita_Gabriel_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public SelectList AuthorList { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public int? AuthorID { get; set; }

        public async Task OnGetAsync()
        {
            AuthorList = new SelectList(_context.Author
                .OrderBy(a => a.LastName)
                .Select(a => new { a.ID, FullName = a.FirstName + " " + a.LastName }), "ID", "FullName", AuthorID);

            var books = _context.Book
                .Include(b => b.Publisher)
                .Include(b => b.Author)
                .AsQueryable();

            if (AuthorID != null)
            {
                books = books.Where(b => b.AuthorID == AuthorID);
            }

            Book = await books.ToListAsync();
        }
    }
}
