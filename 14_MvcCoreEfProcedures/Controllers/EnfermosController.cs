using _14_MvcCoreEfProcedures.Models;
using _14_MvcCoreEfProcedures.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _14_MvcCoreEfProcedures.Controllers
{
    public class EnfermosController : Controller
    {
        private RepositoryEnfermos repo;

        public EnfermosController (RepositoryEnfermos repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<Enfermo> enfermos = this.repo.GetEnfermos();
            return View(enfermos);
        }

        public IActionResult Details(int inscripcion)
        {
            Enfermo enfermo = this.repo.FindEnfermo(inscripcion);
            return View(enfermo);
        }

        public IActionResult Delete(int inscripcion)
        {
            this.repo.DeleteEnfermo(inscripcion);
            return RedirectToAction("Index");
        }
    }
}
