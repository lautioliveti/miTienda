using Microsoft.EntityFrameworkCore;
using MiTienda.Entities;
using MiTienda.Repositories;
using MiTienda.Models;

namespace MiTienda.Services
{
    public class CategoryServices(GenericRepository<Categoria> _categoriaRepository)
    {
        public async Task<IEnumerable<CategoriaVM>> GetAllAsync()
        {
            var categorias = await _categoriaRepository.GetAllAsync();
            var categoriasVM = categorias.Select(item =>
            new CategoriaVM
            {
                CategoriaID = item.CategoriaID,
                CategoriaNombre = item.CategoriaNombre,
            }).ToList();

            return categoriasVM;
        }

        public async Task AddAsync(CategoriaVM viewModel)
        {
            var entity = new Categoria
            {
                CategoriaNombre = viewModel.CategoriaNombre
            };
            await _categoriaRepository.AddAsync(entity);
        }

        public async Task<CategoriaVM?> GetByIdAsync(int id)
        {
            var categoria = await _categoriaRepository.GetByidAsync(id);

            // 1. Primero verifica si existe. Si es null, devuelve null al controlador.
            if (categoria == null)
            {
                return null;
            }

            // 2. Aquí está el arreglo: Usamos llaves { } para llenar los datos
            // en el momento de la creación. Esto elimina el error rojo.
            var categoriaVM = new CategoriaVM
            {
                CategoriaID = categoria.CategoriaID,
                // Usamos ?? "" por si acaso el nombre viene nulo de la BD, para que no rompa
                CategoriaNombre = categoria.CategoriaNombre ?? ""
            };

            return categoriaVM;
        }

        public async Task EditAsync(CategoriaVM viewModel)
        {
            var entity = new Categoria
            {
                CategoriaID = viewModel.CategoriaID,
                CategoriaNombre = viewModel.CategoriaNombre,
            };

            await _categoriaRepository.EditAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var categoria = await _categoriaRepository.GetByidAsync(id);
            await _categoriaRepository.DeleteAsync(categoria!);
        }
    }
}
