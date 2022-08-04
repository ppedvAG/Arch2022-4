using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ppedv.Hotelity.Logic;
using ppedv.Hotelity.Model.Contracts;
using ppedv.Hotelity.Model.DomainModel;


namespace ppedv.Hotelity.UI.WebMVC.Controllers
{
    public class GastController : Controller
    {
        Core _core;

        public GastController(IMainRepository uow)
        {
            _core = new Core(uow);
        }

        // GET: GastController
        public ActionResult Index()
        {
            return View(_core.UnitOfWork.GetRepo<Gast>().Query());
        }

        // GET: GastController/Details/5
        public ActionResult Details(int id)
        {
            return View(_core.UnitOfWork.GetRepo<Gast>().GetId(id));
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
                _core.UnitOfWork.GetRepo<Gast>().Add(gast);
                _core.UnitOfWork.SaveAll();

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
            return View(_core.UnitOfWork.GetRepo<Gast>().GetId(id));
        }

        // POST: GastController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Gast gast)
        {
            try
            {
                _core.UnitOfWork.GetRepo<Gast>().Update(gast);
                _core.UnitOfWork.SaveAll();

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
            return View(_core.UnitOfWork.GetRepo<Gast>().GetId(id));
        }

        // POST: GastController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Gast gast)
        {
            try
            {
                _core.UnitOfWork.GetRepo<Gast>().Delete(gast);
                _core.UnitOfWork.SaveAll();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
