using Dapper;
using G02_03_Dapper_Intro.Models;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

string credenziali = "" +
    "Server=BOOK-N57JVKH6HJ\\SQLEXPRESS;" +
    "Database=g02_01_dapper_intro;" +
    "User Id=academy;" +
    "Password=academy!;" +
    "MultipleActiveResultSets=true;" +
    "Encrypt=false;" +
    "TrustServerCertificate=false";

using (var con = new SqlConnection(credenziali))
{
    var sw = Stopwatch.StartNew();

    var risultato = con.Query<Persona>(
        "SELECT personaID, nome, cognome, cod_fis, numero_mezzi " +
        "   FROM Persona" +
        "   WHERE nome = @nome AND cognome = @cognome", 
        new { 
            @nome = "Giulia",
            @cognome = "Verdi"
        });

    sw.Stop();
    Console.WriteLine($"Tempo impiegato {sw.ElapsedMilliseconds}");

    foreach (Persona persona in risultato)
        Console.WriteLine(persona);
}