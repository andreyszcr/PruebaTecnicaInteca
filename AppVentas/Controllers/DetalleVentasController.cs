using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppVentas.Controllers
{
    public class DetalleVentasController : Controller
    {
        // GET: DetalleVentasController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DetalleVentasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DetalleVentasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DetalleVentasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DetalleVentasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DetalleVentasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DetalleVentasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DetalleVentasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
