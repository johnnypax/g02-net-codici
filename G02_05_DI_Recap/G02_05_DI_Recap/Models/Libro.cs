using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G02_05_DI_Recap.Models
{
    internal class Libro
    {
        public int LibroId { get; set; }
        public string Titolo { get; set; } = null!;
        public string? Descrizione { get; set; }
        public string Isbn { get; set; } = null!;
        public int Anno { get; set; }

        public override string ToString()
        {
            return $"{LibroId} {Titolo} {Descrizione} {Isbn} {Anno}";
        }
    }
}
