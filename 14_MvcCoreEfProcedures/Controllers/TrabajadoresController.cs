using _14_MvcCoreEfProcedures.Models;
using _14_MvcCoreEfProcedures.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _14_MvcCoreEfProcedures.Controllers
{
    public class TrabajadoresController : Controller
    {
        private RepositoryTrabajadores repo;

        public TrabajadoresController(RepositoryTrabajadores repo)
        {
            this.repo = repo;
        }

        public IActionResult TrabajadoresOficio()
        {
            List<Trabajador> trabajadores = this.repo.GetTrabajadores();

            List<string> oficios = this.repo.GetOficios();
            ViewData["OFICIOS"] = oficios;

            ViewData["TRABAJADORES"] = trabajadores;

            return View();
        }

        [HttpPost]
        public IActionResult TrabajadoresOficio(string oficio)
        {
            TrabajadoresModel model = this.repo.GetTrabajadoresOficio(oficio);

            List<string> oficios = this.repo.GetOficios();
            ViewData["OFICIOS"] = oficios;

            return View(model);
        }
    }
}
