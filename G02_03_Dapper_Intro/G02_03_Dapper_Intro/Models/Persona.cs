using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G02_03_Dapper_Intro.Models
{
    internal class Persona
    {
        public int PersonaID { get; set; }
        public string Nome { get; set; } = null!;
        public string Cognome { get; set; } = null!;
        public string Cod_Fis { get; set; } = null!;
        public int Numero_Mezzi { get; set; } = 0;

        public override string ToString()
        {
            return $"[PERSONA] {PersonaID} {Nome} {Cognome} {Cod_Fis} {Numero_Mezzi}";
        }

    }
}
