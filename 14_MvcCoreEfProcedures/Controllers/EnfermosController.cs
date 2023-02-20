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
    }
}
