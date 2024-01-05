using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TE.Core.Domain;
using TE.Core.Services;

namespace TE.UI.WEB.Controllers
{
    public class CandidatureController : Controller
    {
        readonly IService<Candidature> service;
        public CandidatureController(IService<Candidature> service)
        {
            this.service = service;
        }

        // GET: CandidatureController
        public ActionResult Index(int Matricule)
        {
            return View(service.GetAll().Where(c => c.EnseignantFk == Matricule));
        }

        // GET: CandidatureController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CandidatureController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CandidatureController/Create
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

        // GET: CandidatureController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CandidatureController/Edit/5
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

        // GET: CandidatureController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CandidatureController/Delete/5
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
