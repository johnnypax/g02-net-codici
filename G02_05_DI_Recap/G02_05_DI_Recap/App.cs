using G02_05_DI_Recap.Context;
using G02_05_DI_Recap.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G02_05_DI_Recap
{
    internal class App
    {
        private readonly LibreriaContext _context;
        public App(LibreriaContext context)
        {
            _context = context;
        }

        public async Task RunAsync()
        {
            try
            {
                var lib = new Libro()
                {
                    Titolo = "Prova",
                    Descrizione = "Provaprova",
                    Anno = 2025,
                    Isbn = "BLABLA"
                };

                _context.Libros.Add(lib);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
            var sw = Stopwatch.StartNew();
            var listaLibri = await GetLibrosAsync();
            sw.Stop();

            foreach (var libro in listaLibri)
            {
                Console.WriteLine(libro);
            }

            Console.WriteLine($"Tempo impiegato {sw.ElapsedMilliseconds}");
        }

        public async Task<IEnumerable<Libro>> GetLibrosAsync()
        {
            return await _context.Libros.ToListAsync();
        }
    }
}
