using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G02_Test_01_Fact_Theory.Services
{
    public class StudenteService
    {
        public string InsertTest()
        {
            return "SUCCESS: Ok!";
        }

        public string InsertStudente(string nome, string cognome)
        {
            return $"SUCCESS: {nome} {cognome}";
        }
    }
}
