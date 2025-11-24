using Microsoft.AspNetCore.Mvc;
using MiTienda.Models;
using MiTienda.Services;


namespace MiTienda.Controllers
{
    public class CategoriaController(CategoryServices _categoryServices) : Controller

    {
        public async Task<IActionResult> Index()
        {
            var categorias = await _categoryServices.GetAllAsync();
            return View(categorias);
        }

        [HttpGet]
        public async Task<IActionResult> AddEdit(int id)
        {
            // Si el ID es 0, significa que queremos CREAR una nueva categoría.
            // Enviamos un objeto vacío para que la vista no sea null.
            if (id == 0)
            {
                return View(new CategoriaVM());
            }

            // Si el ID es distinto de 0, buscamos la categoría para EDITAR.
            var categoriaVm = await _categoryServices.GetByIdAsync(id);

            // (Opcional) Seguridad extra: si el ID no existe en la BD, devolvemos NotFound
            if (categoriaVm == null)
            {
                return NotFound();
            }

            return View(categoriaVm);
        }

        [HttpPost]
        public async Task<IActionResult> AddEdit(CategoriaVM entityVM)
        {
            ViewBag.message = null;
            if (!ModelState.IsValid) return View(entityVM);


            if (entityVM.CategoriaID == 0)
            {

                await _categoryServices.AddAsync(entityVM);
                ModelState.Clear();
                entityVM = new CategoriaVM();
                ViewBag.message = "Ha sido creada la categoria";
            }
            else
            {
                await _categoryServices.EditAsync(entityVM);
                ViewBag.message = "Ha sido editada la categoria";
            }

            return View(entityVM);
        }

        public async Task<IActionResult>Delete(int id)
        { 
            await _categoryServices.DeleteAsync(id);
            return RedirectToAction("Index");
        }

    }
}
