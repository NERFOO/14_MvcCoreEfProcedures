using _14_MvcCoreEfProcedures.Models;
using _14_MvcCoreEfProcedures.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _14_MvcCoreEfProcedures.Controllers
{
    public class DoctoresController : Controller
    {
        private RepositoryDoctores repo;

        public DoctoresController(RepositoryDoctores repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<Doctor> doctores = this.repo.GetDoctores();

            List<string> especialidades = this.repo.GetEspecialidades();
            ViewData["ESPECIALIDADES"] = especialidades;

            return View(doctores);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string especialidad, int incremento)
        {
            await this.repo.IncrementarSalarioDoctoresAsync(especialidad, incremento);

            List<Doctor> doctores = this.repo.GetDoctoresEspecialidad(especialidad);

            List<string> especialidades = this.repo.GetEspecialidades();
            ViewData["ESPECIALIDADES"] = especialidades;

            return View(doctores);
        }
    }
}
