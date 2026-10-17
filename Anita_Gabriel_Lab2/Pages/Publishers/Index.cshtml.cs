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

namespace Anita_Gabriel_Lab2.Pages.Publishers
{
    public class IndexModel : PageModel
    {
        private readonly Anita_Gabriel_Lab2.Data.Anita_Gabriel_Lab2Context _context;

        public IndexModel(Anita_Gabriel_Lab2.Data.Anita_Gabriel_Lab2Context context)
        {
            _context = context;
        }

        public IList<Publisher> Publisher { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Publisher = await _context.Publisher.ToListAsync();
        }
    }
}
