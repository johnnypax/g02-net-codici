using G02_Test_02_Oggetti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G02_Test_02_Oggetti.Services
{
    public class StudenteService
    {
        public Studente InsertStudente(string nom, string cog)
        {
            var stu = new Studente()
            {
                Nome = nom,
                Cognome = cog,
                Matricola = Guid.NewGuid().ToString(),
                //Matricola = "CIAO"
            };

            return stu;
        }
    }
}
