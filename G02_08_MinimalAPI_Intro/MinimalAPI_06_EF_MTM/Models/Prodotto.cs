namespace MinimalAPI_06_EF_MTM.Models
{
    public class Prodotto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Prezzo { get; set; }
        public string? CodiceABarre { get; set; }
        public List<ProdottoCategoria> ProdottoCategorias { get; set; } = new();
    }
}
