using G02_07_EF_CF_OTM.Models;
using G02_07_EF_CF_OTM.Repositories;

namespace G02_07_EF_CF_OTM.Services
{
    public class AutoreService : IService<AutoreDTO>
    {
        private readonly AutoreRepo _repo;
        private readonly LibroService _libroService;
        public AutoreService(AutoreRepo repo, LibroService service)
        {
            _repo = repo;
            _libroService = service;
        }

        public AutoreDTO? CercaPerCodice(string codice)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AutoreDTO> CercaTutti()
        {
            ICollection<AutoreDTO> risultato = new List<AutoreDTO>();

            IEnumerable<Autore> autori = _repo.GetAll();
            foreach (var a in autori)
            {
                AutoreDTO temp = new()
                {
                    Cod = a.Codice,
                    Nom = a.Nome,
                    Ele = _libroService.CercaPerAutore(a.AutoreID)
                };
                risultato.Add(temp);
            }

            return risultato;
        }

        public bool Elimina(AutoreDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Inserisci(AutoreDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Modifica(AutoreDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
