namespace MinimalAPI_06_EF_MTM.Models
{
    public class ProdottoCategoria
    {
        public int ProdottoId { get; set; }
        public Prodotto ProdottoNav { get; set; } = null!;
        public int CategoriaId { get; set; }
        public Categoria CategoriaNav { get; set; } = null!;
    }
}
