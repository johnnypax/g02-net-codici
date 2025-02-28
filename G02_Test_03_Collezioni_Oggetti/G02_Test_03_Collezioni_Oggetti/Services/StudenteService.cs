using Collezioni_Oggetti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collezioni_Oggetti.Services
{
    public class StudenteService
    {
        private ICollection<Studente> elenco = new List<Studente>();

        public int NumeroStudenti()
        {
            return elenco.Count;    
        }

        public ICollection<Studente> FindAll()
        {
            return elenco;
        }

        public bool InsertStudente(string nom, string cog)
        {
            if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(cog))
                return false;

            Studente stu = new Studente() { Cognome = cog, Nome = nom };

            elenco.Add(stu);
            return true;
        }
    }
}
