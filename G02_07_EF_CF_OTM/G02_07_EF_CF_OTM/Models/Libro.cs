namespace G02_07_EF_CF_OTM.Models
{
    public class Libro
    {
        public int LibroID { get; set; }
        public string Isbn { get; set; } = null!;
        public string Titolo { get; set; } = null!;
        public int AutoreRIF { get; set; }
        public Autore AutoreNav { get; set; } = null!;
    }
}
