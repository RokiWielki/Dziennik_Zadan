using Dziennik_Zadan.Models;

namespace Dziennik_Zadan.Repositories
{
    public class ZadaniaRepository : IZadaniaRepository
    {
        private readonly DziennikZadanContext _context;
        public ZadaniaRepository(DziennikZadanContext context)
        {
            _context=context;
        }
        public ZadaniaModel Get(int id) => _context.Zadania.SingleOrDefault(x => x.ZadaniaId == id);
        public IQueryable<ZadaniaModel> GetAllActive() => _context.Zadania.Where(x => !x.Zrobione);
        public IQueryable<ZadaniaModel> GetDisActive() => _context.Zadania.Where(x => x.Zrobione);
        public void Add(ZadaniaModel zadania)
        {
            _context.Zadania.Add(zadania);
            _context.SaveChanges();
        }
        public void Update(int ZadaniaId, ZadaniaModel zadania)
        {
            var neww= _context.Zadania.SingleOrDefault(x => x.ZadaniaId == ZadaniaId);
            if(neww!= null)
            {
                neww.Nazwa = zadania.Nazwa;
                neww.Wytyczne=zadania.Wytyczne;
                neww.Zrobione=zadania.Zrobione;

                _context.SaveChanges();
            }
        }

        public void Delete(int ZadaniaId)
        {
            var del=_context.Zadania.SingleOrDefault(x=>x.ZadaniaId==ZadaniaId);
            if (del != null)
            {
                _context.Zadania.Remove(del);
                _context.SaveChanges();
            }
        }

    }
}
