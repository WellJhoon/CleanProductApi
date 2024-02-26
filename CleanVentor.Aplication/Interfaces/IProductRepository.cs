using CleanVentor.Domain.Models;
using System.Collections.Generic;

namespace CleanVentor.Aplication.Interfaces
{
    public interface IProductRepository
    {
        List<Products> GetAllProducts(); //Get all products
        Products GetProductById(int id); // Get For Id
        Products CreateProduct(Products product); //Make a product
        void UpdateProduct(Products product); // Update For id
        void DeleteProduct(int id); // Delete For Id
    }
}
