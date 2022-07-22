using Dapper;
using ManejoPresupuesto.Models;
using ManejoPresupuesto.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ManejoPresupuesto.Controllers
{
    public class TiposCuentasController : Controller
    {
        private readonly IRepositorioTiposCuentas repoTiposCuentas;

        public TiposCuentasController(IRepositorioTiposCuentas repoTiposCuentas)
        {
            this.repoTiposCuentas = repoTiposCuentas;
        }

        public async Task<IActionResult> Index()
        {
            var usuarioId = 1;
            var tiposCuentas = await repoTiposCuentas.Obtener(usuarioId);
            return View(tiposCuentas);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(TipoCuenta tipoCuenta)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoCuenta);
            }

            tipoCuenta.UsuarioId = 1;

            var yaExiste = await repoTiposCuentas.Existe(tipoCuenta.Nombre, tipoCuenta.UsuarioId);

            if (yaExiste)
            {
                ModelState.AddModelError(nameof(tipoCuenta.Nombre), $"El nombre {tipoCuenta.Nombre} ya existe.");

                return View(tipoCuenta);
            }

            await repoTiposCuentas.Crear(tipoCuenta);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> VerificarExisteTipoCuenta(string nombre)
        {
            var usuarioId = 1;
            var yaExiste = await repoTiposCuentas.Existe(nombre, usuarioId);

            if (yaExiste)
            {
                return Json("$El nombre {nombre} ya existe");

            }

            return Json(true);
        }
    }
}
