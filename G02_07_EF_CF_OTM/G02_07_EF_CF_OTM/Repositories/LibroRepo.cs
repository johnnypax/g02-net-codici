using G02_07_EF_CF_OTM.Context;
using G02_07_EF_CF_OTM.Models;

namespace G02_07_EF_CF_OTM.Repositories
{
    public class LibroRepo : IRepoLettura<Libro>, IRepoScrittura<Libro>
    {
        private readonly LibrerieContext _context;
        public LibroRepo(LibrerieContext context)
        {
            _context = context;
        }

        public bool Create(Libro entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Libro entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Libro> GetAll()
        {
            return _context.Libros.ToList();
        }

        public Libro? GetById(int id)
        {
            return _context.Libros.FirstOrDefault(a => a.LibroID == id);
        }

        public bool Update(Libro entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Libro> GetByAutore(int rif)
        {
            return _context.Libros.Where(l => l.AutoreRIF == rif).ToList();
        }
    }
}
