using Dziennik_Zadan.Models;

namespace Dziennik_Zadan.Repositories
{
    public interface IZadaniaRepository
    {
        ZadaniaModel Get(int id);
        IQueryable<ZadaniaModel> GetAllActive();
        IQueryable<ZadaniaModel> GetDisActive();
        void Add(ZadaniaModel zadania);
        void Update(int ZadaniaId, ZadaniaModel zadania);
        void Delete(int ZadaniaId);
        
    }
}
