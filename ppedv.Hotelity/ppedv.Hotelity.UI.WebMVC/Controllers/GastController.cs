using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ppedv.Hotelity.Logic;
using ppedv.Hotelity.Model;
using ppedv.Hotelity.Model.Contracts;

namespace ppedv.Hotelity.UI.WebMVC.Controllers
{
    public class GastController : Controller
    {
        Core _core;

        public GastController(IRepository repo)
        {
            _core = new Core(repo);
        }

        // GET: GastController
        public ActionResult Index()
        {
            return View(_core.Repository.GetAll<Gast>());
        }

        // GET: GastController/Details/5
        public ActionResult Details(int id)
        {
            return View(_core.Repository.GetId<Gast>(id));
        }

        // GET: GastController/Create
        public ActionResult Create()
        {
            return View(new Gast() { Name = "NEU" });
        }

        // POST: GastController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Gast gast)
        {
            try
            {
                _core.Repository.Add(gast);
                _core.Repository.SaveAll();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GastController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_core.Repository.GetId<Gast>(id));
        }

        // POST: GastController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Gast gast)
        {
            try
            {
                _core.Repository.Update(gast);
                _core.Repository.SaveAll();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GastController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_core.Repository.GetId<Gast>(id));
        }

        // POST: GastController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Gast gast)
        {
            try
            {
                _core.Repository.Delete(gast);
                _core.Repository.SaveAll();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
