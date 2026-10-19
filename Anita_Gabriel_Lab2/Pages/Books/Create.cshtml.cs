using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Anita_Gabriel_Lab2.Data;
using Anita_Gabriel_Lab2.Models;

namespace Anita_Gabriel_Lab2.Pages.Books
{
    public class CreateModel : BookCategoriesPageModel
    {
        private readonly Anita_Gabriel_Lab2Context _context;

        public CreateModel(Anita_Gabriel_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        // Când deschizi pagina Create
        public IActionResult OnGet()
        {
            var authorList = _context.Author.Select(x => new
            {
                x.ID,
                FullName = x.LastName + " " + x.FirstName
            });
            ViewData["AuthorID"] = new SelectList(authorList, "ID", "FullName");
            ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID", "PublisherName");

            // carte nouă, fără categorii -> toate checkbox-urile nebifate
            var book = new Book();
            book.BookCategories = new List<BookCategory>();
            PopulateAssignedCategoryData(_context, book);

            return Page();
        }

        // Când apeși Create
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            Book.BookCategories = new List<BookCategory>();

            // pentru fiecare categorie bifată, creăm o legătură
            if (selectedCategories != null)
            {
                foreach (var cat in selectedCategories)
                {
                    Book.BookCategories.Add(new BookCategory
                    {
                        CategoryID = int.Parse(cat)
                    });
                }
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}