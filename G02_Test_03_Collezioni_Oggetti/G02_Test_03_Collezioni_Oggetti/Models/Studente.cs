using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collezioni_Oggetti.Models
{
    public class Studente
    {
        public string Nome { get; set; } = string.Empty;
        public string Cognome { get; set; } = string.Empty;
        public DateTime Ts { get; set; } = DateTime.Now;
    }
}
