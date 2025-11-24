using Microsoft.AspNetCore.Mvc;
using MiTienda.Context;
using MiTienda.Entities;
using MiTienda.Models;

namespace MiTienda.Controllers
{
    public class CategoriaController(AppDbContext _dbContext) : Controller

    {
        public IActionResult Index()
        {
            var categorias = _dbContext.Categoria.Select(item =>
            new CategoriaVM
            {
                CategoriaID = item.CategoriaID,
                CategoriaNombre = item.CategoriaNombre,
            }).ToList();
            return View(categorias);
        }
    }
}
