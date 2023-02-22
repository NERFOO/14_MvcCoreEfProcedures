using _14_MvcCoreEfProcedures.Models;
using _14_MvcCoreEfProcedures.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _14_MvcCoreEfProcedures.Controllers
{
    public class EmpleadosVistaController : Controller
    {
        private RepositoryVistaEmpleados repo;

        public EmpleadosVistaController (RepositoryVistaEmpleados repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<VistaEmpleado> empleados = this.repo.GetEmpleados();
            return View(empleados);
        }
    }
}
