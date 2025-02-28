namespace MinimalAPI_06_EF_MTM.Models
{
    public class CategoriaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        public List<string> Prodottos { get; set; } = new();
    }
}
