using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Anita_Gabriel_Lab2.Models;
using Anita_Gabriel_Lab2.Data;

namespace Anita_Gabriel_Lab2.Pages.CategoryPages;

public class IndexModel : PageModel
{
    private readonly Anita_Gabriel_Lab2Context _context;

    public IndexModel(Anita_Gabriel_Lab2Context context)
    {
        _context = context;
    }

    public IList<Category> Category { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Category = await _context.Category.ToListAsync();
    }
}
