using G02_05_DI_Recap.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G02_05_DI_Recap.Context
{
    internal class LibreriaContext : DbContext
    {
        public DbSet<Libro> Libros { get; set; }

        public LibreriaContext(DbContextOptions<LibreriaContext> options) : base(options) { }

    }
}
