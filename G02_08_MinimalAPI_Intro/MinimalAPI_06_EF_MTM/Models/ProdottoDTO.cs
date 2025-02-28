namespace MinimalAPI_06_EF_MTM.Models
{
    public class ProdottoDTO
    {
        public string Nome { get; set; } = string.Empty;
        public decimal Prezzo { get; set; }
        public string? CodiceABarre { get; set; }
        public List<string> Categorias { get; set; } = new();
    }
}
