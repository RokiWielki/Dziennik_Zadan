using Dziennik_Zadan.Models;
using Dziennik_Zadan.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace Dziennik_Zadan.Controllers
{
    public class ZadaniaController : Controller
    {
        private readonly IZadaniaRepository _zadania;
        public ZadaniaController(IZadaniaRepository zadaniaRepository)
        {
            _zadania= zadaniaRepository;
        }
        private static IList<ZadaniaModel> zadaniaZrobione = new List<ZadaniaModel>();
        // GET: ZadaniaController

        public ActionResult Index()
        {
            return View(_zadania.GetAllActive());
        }

        // GET: ZadaniaController/Details/5
        public ActionResult Details(int id)
        {
            return View(_zadania.Get(id));
        }

        // GET: ZadaniaController/Create
        public ActionResult Create()
        {
            return View(new ZadaniaModel());
        }

        // POST: ZadaniaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ZadaniaModel collection)
        {
            _zadania.Add(collection);
            
            return RedirectToAction(nameof(Index));
        }

        // GET: ZadaniaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_zadania.Get(id));
        }

        // POST: ZadaniaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ZadaniaModel collection)
        {
            _zadania.Update(id, collection);

            return RedirectToAction(nameof(Index));

        }

        // GET: ZadaniaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_zadania.Get(id));
        }

        // POST: ZadaniaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ZadaniaModel collection)
        {
            _zadania.Delete(id);
            return RedirectToAction(nameof(Index));

        }
        public ActionResult Done(int id)
        {
            ZadaniaModel done = _zadania.Get(id);
            done.Zrobione = true;
            _zadania.Update(id,done);

            return RedirectToAction(nameof(Index));
        }
    }
}
