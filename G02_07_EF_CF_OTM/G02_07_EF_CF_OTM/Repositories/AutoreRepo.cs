using G02_07_EF_CF_OTM.Context;
using G02_07_EF_CF_OTM.Models;

namespace G02_07_EF_CF_OTM.Repositories
{
    public class AutoreRepo : IRepoLettura<Autore>, IRepoScrittura<Autore>
    {
        private readonly LibrerieContext _context;
        public AutoreRepo(LibrerieContext context)
        {
            _context = context;
        }

        public bool Create(Autore entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Autore entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Autore> GetAll()
        {
            return _context.Autores.ToList();
        }

        public Autore? GetById(int id)
        {
            return _context.Autores.FirstOrDefault(a => a.AutoreID == id);
        }

        public bool Update(Autore entity)
        {
            throw new NotImplementedException();
        }

    }
}
