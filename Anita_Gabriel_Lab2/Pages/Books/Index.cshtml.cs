using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Anita_Gabriel_Lab2.Data;
using Anita_Gabriel_Lab2.Models;

namespace Anita_Gabriel_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Anita_Gabriel_Lab2Context _context;

        public IndexModel(Anita_Gabriel_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; } = default!;   // folosit doar pentru numele coloanelor
        public BookData BookD { get; set; }
        public int BookID { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID)
        {
            BookD = new BookData();

            // aducem toate cărțile, cu editura, autorul și categoriile lor
            BookD.Books = await _context.Book
                .Include(b => b.Publisher)
                .Include(b => b.Author)
                .Include(b => b.BookCategories)
                    .ThenInclude(b => b.Category)
                .AsNoTracking()
                .OrderBy(b => b.Title)
                .ToListAsync();

            if (id != null)
            {
                BookID = id.Value;
                Book book = BookD.Books.Where(i => i.ID == id.Value).Single();
                BookD.Categories = book.BookCategories.Select(s => s.Category);
            }
        }
    }
}