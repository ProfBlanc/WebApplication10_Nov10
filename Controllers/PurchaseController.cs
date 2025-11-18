using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication10_Nov10.Models;
using WebApplication10_Nov10.Repository;

namespace WebApplication10_Nov10.Controllers
{
    public class PurchaseController : Controller
    {

        private readonly IPurchaseRepository _repo;

        public PurchaseController(IPurchaseRepository repo)
        {
            _repo = repo;
        }



        // GET: PurchaseController
        public ActionResult Index()
        {
            return View(_repo.GetAll());
        }

        // GET: PurchaseController/Details/5
        public ActionResult Details(int id)
        {
            return View(_repo.GetById(id));
        }

        // GET: PurchaseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PurchaseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Purchase purchase)
        {

            if (ModelState.IsValid) {

                _repo.Add(purchase);
                return RedirectToAction(nameof(Index));

            }
                return View();
        }

            // GET: PurchaseController/Edit/5
            public ActionResult Edit(int id)
        {

            Purchase item = _repo.GetById(id);
            if (item != null) {

                return View(item);
            }
            return NotFound();


            
        }

        // POST: PurchaseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Purchase purchase)
        {
            if (_repo.Update(id, purchase)) {

                return RedirectToAction(nameof(Index));
            }
            return View(purchase);
            
        }

        // GET: PurchaseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PurchaseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Purchase purchase)
        {
            if (id == purchase.PurchaseId && _repo.Delete(id)) {

                return RedirectToAction(nameof(Index));
            }
            return NotFound();
            
        }
    }
}
