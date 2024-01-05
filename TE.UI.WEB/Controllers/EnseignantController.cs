using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TE.Core.Domain;
using TE.Core.Services;

namespace TE.UI.WEB.Controllers
{
    public class EnseignantController : Controller
    {
        readonly IService<Enseignant> service;

        public EnseignantController (IService<Enseignant> service)
        {
            this.service = service;
        }

        // GET: EnseignantController
        public ActionResult Index(string f1,string f2)
        {
            if (!(string.IsNullOrEmpty(f1) && string.IsNullOrEmpty(f2)))
                return View(service.GetAll()
                .Where(f => f.MyUP.Nom == f1 || f.Candidatures.Any(c => c.MyConcours.Promotion.ToString() == f2)));
            return View(service.GetAll());
        }

        // GET: EnseignantController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EnseignantController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EnseignantController/Create
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

        // GET: EnseignantController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EnseignantController/Edit/5
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

        // GET: EnseignantController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EnseignantController/Delete/5
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
