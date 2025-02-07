using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G02_04_Dependency_Injection.Context
{
    internal class LibreriaContext : DbContext
    {
        public LibreriaContext(DbContextOptions<LibreriaContext> options) : base(options) { }
        
    }
}
