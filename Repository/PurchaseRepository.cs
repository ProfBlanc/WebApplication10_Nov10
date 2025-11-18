using WebApplication10_Nov10.Data;
using WebApplication10_Nov10.Models;

namespace WebApplication10_Nov10.Repository
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly ApplicationDbContext _context;



        public PurchaseRepository(ApplicationDbContext context) {

            _context = context;
        }

        public void Add(Purchase purchase)
        {
            _context.Purchases.Add(purchase);
            Save();
        }
        
        public bool Delete(int id)
        {
            var item = _context.Purchases.Find(id);
            if(item != null)
            {

                _context.Purchases.Remove(item);
                return true;
            }
            return false;
        }

        public List<Purchase> GetAll()
        {
            return _context.Purchases.ToList();
        }

        public Purchase GetById(int id)
        {
            return _context.Purchases.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool Update(int id, Purchase purchase)
        {
            Purchase item = GetById(id);
            if (id == purchase.PurchaseId) {

                _context.Purchases.Update(item);
                Save();
                return true;

                //Create a controller named: PurhcaseController
                //instead of controller passing ApplicationDbContext as _context
                //rename _context to _repo and change _repo datatype to IPurchaseRepository
            
            }
            return false;
        }
    }
}
