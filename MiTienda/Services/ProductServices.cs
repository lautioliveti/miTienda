using MiTienda.Entities;
using MiTienda.Repositories;
using MiTienda.Models;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;

namespace MiTienda.Services
{
    public class ProductServices(
        GenericRepository<Categoria> _categoriaRepository,
        GenericRepository<Producto> _productoRepository,
        IWebHostEnvironment _webHostEnvironment
        )
    {
        public async Task<IEnumerable<ProductoVM>> GetAllAsync()
        {
            var producto = await _productoRepository.GetAllAsync(
                includes: new Expression<Func<Producto, object>>[] { x => x.Categoria! }
                );


            var productoVM = producto.Select(item =>
                new ProductoVM
                {
                    ProductoID = item.ProductoID,
                    ProductoCategoria = new CategoriaVM
                    {
                        CategoriaID = item.Categoria!.CategoriaID,
                        CategoriaNombre = item.Categoria!.CategoriaNombre
                    },
                    ProductoNombre = item.ProductoNombre,
                    ProductoDescripcion = item.ProductoDescripcion,
                    ProductoPrecio = item.ProductoPrecio,
                    ProductoStock = item.ProductoStock,
                    ProductoImagen = item.ProductoImagen,

                }).ToList();
            return productoVM;

        }

        public async Task <ProductoVM> GetByidAsync(int id)
        {
            var producto = await _productoRepository.GetByidAsync(id);
            var categorias = await _categoriaRepository.GetAllAsync();


            var productoVM = new ProductoVM();
            if(producto != null)
            {
                productoVM = new ProductoVM
                {
                    ProductoID = producto.ProductoID,
                    ProductoCategoria= new CategoriaVM
                    {
                        CategoriaID = producto.Categoria.CategoriaID,
                        CategoriaNombre = producto.Categoria!.CategoriaNombre
                    },
                    ProductoNombre  = producto.ProductoNombre,
                    ProductoDescripcion =  producto.ProductoDescripcion,   
                    ProductoPrecio= producto.ProductoPrecio,   
                    ProductoStock= producto.ProductoStock,
                    ProductoImagen= producto.ProductoImagen,
                };
                
            }

            productoVM.Categorias = categorias.Select(item => new SelectListItem
            {
                Value = item.CategoriaID.ToString(),
                Text = item.CategoriaNombre,
            }).ToList();

            return productoVM;
        }

        public async Task AddAsync(ProductoVM viewModel)
        {
            if (viewModel.ImageFile != null)
            {
                string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(viewModel.ImageFile.FileName);
                string filePath = Path.Combine(uploadFolder, uniqueFileName);
                
                using(var fileStream = new FileStream(filePath,FileMode.Create))
                    await viewModel.ImageFile.CopyToAsync(fileStream);

                viewModel.ProductoImagen = uniqueFileName;
            }

            var entity = new Producto
            {
                ProductoCategoria = viewModel.ProductoCategoria.CategoriaID,
                ProductoNombre = viewModel.ProductoNombre,
                ProductoDescripcion = viewModel.ProductoDescripcion,
                ProductoPrecio = viewModel.ProductoPrecio,
                ProductoImagen = viewModel.ProductoImagen,
            };

            await _productoRepository.AddAsync(entity);
        }

        public async Task EditAsync(ProductoVM viewModel)
        {
            var producto = await _productoRepository.GetByidAsync(viewModel.ProductoID);

            if (viewModel.ImageFile != null)
            {
                string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(viewModel.ImageFile.FileName);
                string filePath = Path.Combine(uploadFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                    await viewModel.ImageFile.CopyToAsync(fileStream);

                if (producto.ProductoImagen.IsNullOrEmpty())
                {
                    var previousImage = producto.ProductoImagen;
                    string deleteFilePath = Path.Combine(uploadFolder, previousImage);

                    if(File.Exists(deleteFilePath)) File.Delete(deleteFilePath);

                }

                viewModel.ProductoImagen = uniqueFileName;
            }
            else
            {
                viewModel.ProductoImagen = producto.ProductoImagen;
            }

            producto.ProductoCategoria = viewModel.ProductoCategoria.CategoriaID;
            producto.ProductoNombre = viewModel.ProductoNombre;
            producto.ProductoPrecio= viewModel.ProductoPrecio;
            producto.ProductoDescripcion = viewModel.ProductoDescripcion;
            producto.ProductoStock = viewModel.ProductoStock;   

            await _productoRepository.EditAsync(producto);

        }
        public async Task DeleteAsync(int id)
        {
            var producto = await _productoRepository.GetByidAsync(id);
            await _productoRepository.DeleteAsync(producto);

        }
    }
}
