using WebApplication10_Nov10.Models;

namespace WebApplication10_Nov10.Repository
{
    public interface IPurchaseRepository
    {
        List<Purchase> GetAll();
        Purchase GetById(int id);

        //Add, Update, Delete
        void Add(Purchase purchase);

        bool Update(int id, Purchase purchase);

        bool Delete(int id);

        //
        void Save();
    }
}
