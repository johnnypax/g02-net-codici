using G02_07_EF_CF_OTM.Models;
using G02_07_EF_CF_OTM.Repositories;

namespace G02_07_EF_CF_OTM.Services
{
    public class LibroService : IService<LibroDTO>
    {

        private readonly LibroRepo _repo;
        public LibroService(LibroRepo repo)
        {
            _repo = repo;
        }

        public LibroDTO? CercaPerCodice(string codice)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LibroDTO> CercaTutti()
        {
            throw new NotImplementedException();
        }

        public bool Elimina(LibroDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Inserisci(LibroDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Modifica(LibroDTO entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LibroDTO> CercaPerAutore(int autId)
        {
            ICollection<LibroDTO> risultato = new List<LibroDTO>();

            var elencoLibri = _repo.GetByAutore(autId);
            foreach (var l in elencoLibri)
            {
                LibroDTO temp = new()
                {
                    Isb = l.Isbn,
                    Tit = l.Titolo
                };
                risultato.Add(temp);
            }

            return risultato;
        }
    }
}
