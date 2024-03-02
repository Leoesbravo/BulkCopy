using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Presentacion.Controllers
{
    public class CargaMasivaController : Controller
    {
        public IActionResult Carga()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Carga(IFormFile csv)
        {
           DataTable table = Negocio.Carga.ConvertToDataTable(csv);
            //crear un archivo csv a paritr de table
            //
            //return File(archivo);
            return View();
        }
    }
}
