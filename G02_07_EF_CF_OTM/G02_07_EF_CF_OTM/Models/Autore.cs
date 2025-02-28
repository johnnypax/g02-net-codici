namespace G02_07_EF_CF_OTM.Models
{
    public class Autore
    {
        public int AutoreID { get; set; }
        public string Codice { get; set; } = null!;
        public string Nome { get; set; } = null!;

        public ICollection<Libro> Libri { get; set; } = new List<Libro>();
    }
}
