using System;
using System.Collections.Generic;

namespace G02_06_EF_DB_Negozio.Models;

public partial class Prodotto
{
    public int ProdottoId { get; set; }

    public string Nome { get; set; } = null!;

    public decimal? Prezzo { get; set; }

    public string Codice { get; set; } = null!;
}
