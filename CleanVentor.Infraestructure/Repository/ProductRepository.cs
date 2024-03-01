using CleanVentor.Aplication.Interfaces;
using CleanVentor.Domain.Models;
using CleanVentor.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanVentor.Infraestructure.Repository
{
    // Repositorio para operaciones CRUD en la tabla de productos.
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbcontext _productDbcontext; // Contexto de la base de datos de productos.

        // Constructor que recibe el contexto de la base de datos como argumento.
        public ProductRepository(ProductDbcontext productDbcontext)
        {
            _productDbcontext = productDbcontext;
        }

        // Crea un nuevo producto en la base de datos.
        public Products CreateProduct(Products product)
        {
            _productDbcontext.Productss.Add(product);
            _productDbcontext.SaveChanges();
            return product;
        }

        // Obtiene todos los productos de la base de datos.
        public List<Products> GetAllProducts()
        {
            return _productDbcontext.Productss.ToList();
        }

        // Obtiene un producto por su ID de la base de datos.
        public Products GetProductById(int id)
        {
            return _productDbcontext.Productss.FirstOrDefault(p => p.Id == id);
        }

        // Actualiza un producto existente en la base de datos.
        public void UpdateProduct(Products product)
        {
            _productDbcontext.Entry(product).State = EntityState.Modified;
            _productDbcontext.SaveChanges();
        }

        // Elimina un producto de la base de datos por su ID.
        public void DeleteProduct(int id)
        {
            var productToDelete = _productDbcontext.Productss.FirstOrDefault(p => p.Id == id);
            if (productToDelete != null)
            {
                _productDbcontext.Productss.Remove(productToDelete);
                _productDbcontext.SaveChanges();
            }
        }
    }
}
