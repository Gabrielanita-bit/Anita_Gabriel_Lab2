using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Anita_Gabriel_Lab2.Models;

namespace Anita_Gabriel_Lab2.Data
{
    public class Anita_Gabriel_Lab2Context : DbContext
    {
        public DbSet<Anita_Gabriel_Lab2.Models.Category> Category { get; set; } = default!;
        public Anita_Gabriel_Lab2Context (DbContextOptions<Anita_Gabriel_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Anita_Gabriel_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Anita_Gabriel_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Anita_Gabriel_Lab2.Models.Author> Author { get; set; } = default!;
    }
}
