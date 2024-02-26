using CleanVentor.Aplication.Interfaces;
using CleanVentor.Domain.Models;
using CleanVentor.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanVentor.Infraestructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        public static List<Products> products = new List<Products>()
        {
            new Products{Id = 1, Name = "Bebidas", Category = "Bebidas", Description = "Jugo de limon", Stock = 10, UnitPrice = 30},
            new Products{Id = 2, Name = "Comida", Category = "Papas", Description = "Tuberculos", Stock = 20, UnitPrice = 2}
        };
        private readonly ProductDbcontext _productDbcontext;

        public ProductRepository(ProductDbcontext productDbcontext)
        {
            _productDbcontext = productDbcontext;
        }

        public Products CreateProduct(Products product)
        {
            _productDbcontext.Productss.Add(product);
            _productDbcontext.SaveChanges();
            return product;
        }

        public List<Products> GetAllProducts()
        {
            return _productDbcontext.Productss.ToList();
        }

        // Métodos faltantes que se agregaron nuevamente
        public Products GetProductById(int id)
        {
            return _productDbcontext.Productss.FirstOrDefault(p => p.Id == id);
        }

        public void UpdateProduct(Products product)
        {
            _productDbcontext.Entry(product).State = EntityState.Modified;
            _productDbcontext.SaveChanges();
        }

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
