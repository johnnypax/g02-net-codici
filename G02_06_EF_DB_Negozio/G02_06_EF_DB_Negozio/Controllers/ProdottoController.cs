using G02_06_EF_DB_Negozio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace G02_06_EF_DB_Negozio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdottoController : Controller
    {
        //COSA CATTIVA!!!! DEVE ESSERE NECESSARIAMENTE RISTRUTTURATA!!!!
        private readonly G02DfNegozioContext _context;
        public ProdottoController(G02DfNegozioContext context)
        {
            _context = context;
        }

        [HttpGet("semplice")]
        public ActionResult<IEnumerable<Prodotto>> FindDall()
        {
            IEnumerable<Prodotto> lista = _context.Prodottos.ToList();

            return Ok(lista);
        }

        [HttpGet("span")]
        public ActionResult<IEnumerable<Prodotto>> FindDallSpan()
        {
            Span<Prodotto> spanProdotti = _context.Prodottos.AsNoTracking().ToArray();
            for (int i = 0; i < spanProdotti.Length; i++)
            {
                spanProdotti[i].Prezzo *= 1.3m;
            }

            return Ok(spanProdotti.ToArray());
        }


    }
}
