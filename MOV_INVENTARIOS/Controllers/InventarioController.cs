using Microsoft.AspNetCore.Mvc;
using MOV_INVENTARIOS.DA;
using MOV_INVENTARIOS.Models;

namespace MOV_INVENTARIOS.Controllers
{
    public class InventarioController : Controller
    {
        private readonly Mov_inventario_DA _da;

        public InventarioController(Mov_inventario_DA da)
        {
            _da = da;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Mov_Inventario_filtro_ViewModel mov_inventario = new Mov_Inventario_filtro_ViewModel();
            try
            {
                mov_inventario.Listado= _da.GetAll();
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
            }

            return View(mov_inventario);
        }


        [HttpPost]
        public IActionResult Index(Mov_Inventario_filtro_ViewModel mov_inventario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    mov_inventario.Listado = _da.GetByFilter(mov_inventario.FechaI, mov_inventario.FechaF, mov_inventario.Tipo, mov_inventario.Nro);
                }
                else 
                {
                    mov_inventario.Listado = _da.GetAll();
                    View(mov_inventario);
                }

                    
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
            }

            return View(mov_inventario);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Mov_inventario model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["errorMessage"] = "Modelo no es valido";
                }
                bool result = _da.Insert(model);

                if (!result)
                {
                    TempData["errorMessage"] = "Error al guardar";
                }
                TempData["successMessage"] = "Registro completado";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }



    }
}
