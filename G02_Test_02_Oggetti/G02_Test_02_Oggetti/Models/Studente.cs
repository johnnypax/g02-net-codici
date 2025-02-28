using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G02_Test_02_Oggetti.Models
{
    public class Studente
    {
        public string Nome { get; set; } = string.Empty;
        public string Cognome { get; set; } = string.Empty;
        public string Matricola { get; set; } = string.Empty;
        public DateTime TimeStamp { get; set; } = DateTime.Now;


    }
}
