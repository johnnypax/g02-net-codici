namespace G02_07_EF_CF_OTM.Models
{
    public class LibroDTO
    {
        public string Isb { get; set; } = null!;
        public string Tit { get; set; } = null!;
        public AutoreDTO? Aut { get; set; }
    }
}
